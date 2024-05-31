using HandyControl.Controls;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;


namespace Iebcn.Live.Helper
{
	public class Util
	{
		private static string _forbiddenWordsFile = "违禁词.txt";// ForbiddenWords 文件路径
		private static string _settingsFile = "setting.json";// DanmuSetting 文件路径
		/// <summary>
		/// 将给定的日期时间转换为 Unix 时间戳（以秒为单位）
		/// </summary>
		/// <param name="dateTime">要转换的日期时间</param>
		/// <returns>Unix 时间戳</returns>
		public static long DataTimeToTimestamp(DateTime dateTime)
		{
			return (long)dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
		}

		/// <summary>
		/// 判断指定弹幕类型是否在已开启的选项中
		/// </summary>
		/// <param name="optTypes">包含各种弹幕选项的对象</param>
		/// <param name="danmuType">待检查的弹幕类型</param>
		/// <returns>该弹幕类型是否已开启</returns>
		public static bool HasOptTypes(OptTypes optTypes, DanmuType danmuType)
		{
			switch (danmuType)
			{
				case DanmuType.Chat:
					return optTypes.ChatEnabled;
				case DanmuType.EnterRoom:
					return optTypes.EnterRoomEnabled;
				case DanmuType.Like:
					return optTypes.LikeEnabled;
				case DanmuType.Gift:
					return optTypes.GiftEnabled;
				case DanmuType.Follow:
					return optTypes.FollowEnabled;
				case DanmuType.App:
					return true;
				default:
					return false;
			}
		}

		/// <summary>
		/// 检查输入文本是否包含禁止词汇
		/// </summary>
		/// <param name="input">待检查的文本</param>
		/// <returns>是否包含禁止词汇</returns>
		public static bool CheckIsForbiddenWords(string input)
		{
			foreach (string word in Common.ForbiddenWords.Split("|".ToCharArray()).Where(w => !string.IsNullOrEmpty(w.Trim())))
			{
				try
				{
					if (new Regex(word.Trim()).Match(input).Success)
					{
						return true;
					}
				}
				catch (Exception)
				{
					Common.ForbiddenWords = Common.ForbiddenWords.Replace(word.Trim(), "");
				}
			}
			return false;
		}

		/// <summary>
		/// 将 ASCII 码转换为字符
		/// </summary>
		/// <param name="asciiCode">ASCII 码值</param>
		/// <returns>对应的字符</returns>
		public static string ToChr(int asciiCode)
		{
			if (asciiCode < 0 || asciiCode > 255)
			{
				throw new Exception("ASCII Code is not valid.");
			}
			ASCIIEncoding encoding = new ASCIIEncoding();
			byte[] bytes = new byte[1] { (byte)asciiCode };
			return encoding.GetString(bytes);
		}

		/// <summary>
		/// 解析字符串中的 ASCII 码范围，并将其转换为字符
		/// </summary>
		/// <param name="s">包含 ASCII 码范围的字符串（如 "65-90"）</param>
		/// <returns>由指定 ASCII 码范围生成的字符序列</returns>
		public static string ParseAscii(string s)
		{
			string result = "";
			string[] ranges = s.Split('-');
			foreach (string range in ranges)
			{
				result += ToChr(int.Parse(range.ToString()) - 1);
			}
			return result;
		}

		/// <summary>
		/// 获取当前系统信息的简短描述
		/// </summary>
		/// <returns>系统信息字符串</returns>
		private static string CmD()
		{
			string machineName = Environment.MachineName;
			string osVersion = GetOsVersion(Environment.OSVersion.Version);
			string servicePack = Environment.OSVersion.ServicePack;
			string userName = Environment.UserName;
			string userDomainName = Environment.UserDomainName;
			return $"{machineName} {osVersion}{servicePack}  {userDomainName}\\{userName}";
		}

		/// <summary>
		/// 根据操作系统版本号返回其名称
		/// </summary>
		/// <param name="ver">操作系统版本对象</param>
		/// <returns>操作系统名称</returns>
		public static string GetOsVersion(Version ver)
		{
			switch (ver.Major)
			{
				case 5 when ver.Minor == 1:
					return "Win XP";
				case 6 when ver.Minor == 0:
					return "Win Vista";
				case 6 when ver.Minor == 1:
					return "Win 7";
				case 6 when ver.Minor == 2:
					return "Win 10";
				case 5 when ver.Minor == 0:
					return "Win 2000";
				default:
					return "未知";
			}
		}

		/// <summary>
		/// 验证并获取产品激活状态
		/// </summary>
		/// <returns>产品激活结果</returns>
		public static async Task<PdtValidateResult> ValidPdt()
		{
			Common.isVIP = false;
			PdtValidateResult pdtValidateResult = new PdtValidateResult();

			if (!string.IsNullOrEmpty(Config.RegCode))
			{
				string response = await Task.Run(() => ValidatePdt());
				if (string.IsNullOrEmpty(response))
				{
					pdtValidateResult.Msg = "获取注册激活信息失败, 请检查网络!";
					pdtValidateResult.Valid = false;
					pdtValidateResult.IsErr = true;
				}
				else
				{
					response = ParseAscii(response.Trim());
					string[] parts = response.Split('|');

					if (parts.Length < 3 || parts[3].Trim() != GenerateSignature($"s{Config.RegCode}"))
					{
						pdtValidateResult.Msg = "验证失败！";
						pdtValidateResult.Valid = false;
						pdtValidateResult.IsErr = true;
						Common.VIPLevel = 2;
						return pdtValidateResult;
					}

					if (parts[0].Trim() != "1")
					{
						pdtValidateResult.Msg = "产品没有激活,或VIP已经过期，请续费";
						Common.isVIP = false;
						pdtValidateResult.Valid = false;
					}
					else
					{
						pdtValidateResult.Msg = "产品已经激活";
						Common.isVIP = true;
						pdtValidateResult.Valid = true;

						pdtValidateResult.EndDate = DateTime.Parse(parts[1].Trim());
						Common.dateTime_0 = pdtValidateResult.EndDate;
						Common.VIPLevel = int.Parse($"0{parts[2].Trim()}");
					}
				}

				//Common.AppInfo.LogoText = $"{Config.softTitle} v{Config.softVersion}[{Common.VIPLevelTitle}]";
				return pdtValidateResult;
			}

			pdtValidateResult.Msg = "不能获取序列号";
			pdtValidateResult.Valid = false;
			return pdtValidateResult;
		}
		
		/// <summary>
		/// 获取代理ID（或默认为“-”）并发送验证请求。
		/// </summary>
		/// <returns>验证结果字符串。</returns>
		private static string ValidatePdt()
		{
			try
			{
				string agentId = "-";
				// 创建HttpClient实例，设置请求头和编码
				using HttpClient httpClient = new HttpClient
				{
					DefaultRequestHeaders =
				{
					{ "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36" },
				},
					DefaultRequestVersion = new Version(2, 0),
					Timeout = TimeSpan.FromSeconds(30)
				};

				// 构造请求参数
				string systemInfo = CmD();
				string updateContent = "&updateContent=0";
				string requestParams = $"RegCode={Config.RegCode}&pdtName={Config.softTitle}&pdtCode={Config.softCode}&Version={Config.softVersion}&LastSendContent=url{Uri.EscapeDataString(Common.danmuSetting.LastLiveUrl)}&SystemInfo={systemInfo}{updateContent}&aid={agentId}&PCCode={Config.RegCode}&sign={GenerateSignature("s" + Config.RegCode + Config.softCode)}";

				// 发送GET请求并获取响应字符串
				return httpClient.GetStringAsync(Config.AppPdtValidateURL + "?" + requestParams).Result;
			}
			catch (Exception ex)
			{
				// 记录异常信息
				AppLog.AddLog($"验证PDT时发生错误: {ex.Message}");
				return "";
			}
		}

		/// <summary>
		/// 生成给定字符串的MD5签名。
		/// </summary>
		/// <param name="input">待签名的字符串。</param>
		/// <returns>生成的MD5签名字符串。</returns>
		public static string GenerateSignature(string input)
		{
			using MD5 md5 = MD5.Create();
			byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

			StringBuilder signatureBuilder = new StringBuilder(32);
			foreach (byte b in hashBytes)
			{
				signatureBuilder.Append(b.ToString("X2"));
			}

			return signatureBuilder.ToString();
		}

		/// <summary>
		/// 获取计算机唯一标识符（UUID）。
		/// </summary>
		/// <returns>计算机UUID字符串，或在获取失败时返回空字符串。</returns>
		public static string GetComputerUID()
		{
			try
			{
				// 查询WMI获取计算机系统产品实例
				ManagementObjectCollection instances = new ManagementClass("Win32_ComputerSystemProduct").GetInstances();

				// 遍历实例，获取第一个UUID值
				using ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator();
				if (enumerator.MoveNext())
				{
					return ((ManagementObject)enumerator.Current).Properties["UUID"].Value.ToString();
				}
			}
			catch
			{
				// 记录异常信息（可选）
			}

			return "";
		}

		/// <summary>
		/// 加载应用程序配置信息。
		/// </summary>
		public static void LoadConfig()
		{
			VoiceHelper.LoadVoiceList();
			RenqiHelper.LoadUsers();
			GenerateRegistrationCode();
			EventDanmuManager.InitializeEventFiles();
			SilenceHelper.LoadLocalSoundFiles();
		}

		/// <summary>
		/// 保存禁止词列表到文件。
		/// </summary>
		public static void SaveForbiddenWords()
		{
			try
			{
				File.WriteAllText(_forbiddenWordsFile, Common.ForbiddenWords);
			}
			catch (Exception ex)
			{
				AppLog.AddLog($"保存禁止词列表时发生错误: {ex.Message}");
			}
		}

		/// <summary>
		/// 加载弹幕设置信息。
		/// </summary>
		/// <returns>加载后的弹幕设置对象。</returns>
		public static DanmuSetting LoadDanmuSetting()
		{
			try
			{
				// 从文件中反序列化弹幕设置对象
				DanmuSetting danmuSetting = JsonConvert.DeserializeObject<DanmuSetting>(File.ReadAllText(_settingsFile));

				// 初始化可能未赋值的子对象
				danmuSetting.VoiceDanmu ??= new VoiceDanmu();
				//danmuSetting.Live2DRole_0 ??= new Live2DRole();
				//danmuSetting.FakeDanmu ??= new FakeDanmu();

				// 备份当前设置文件
				File.Copy(_settingsFile, "setting_backup.json", overwrite: true);

				return danmuSetting;
			}
			catch (Exception ex)
			{
				AppLog.AddLog($"加载弹幕设置时发生错误: {ex.Message}");
				return new DanmuSetting();
			}
		}

		/// <summary>
		/// 保存弹幕设置信息到文件。
		/// </summary>
		/// <returns>是否成功保存设置。</returns>
		public static bool SaveDanmuSetting()
		{
			try
			{
				string json = JsonConvert.SerializeObject(Common.danmuSetting);
				File.WriteAllText(_settingsFile, json);
				return true;
			}
			catch (Exception ex)
			{
				AppLog.AddLog($"保存弹幕设置时发生错误: {ex.Message}");
				return false;
			}
		}

		/// <summary>
		/// 根据硬件信息生成注册码。
		/// </summary>
		private static void GenerateRegistrationCode()
		{
			string hardwareInfo = $"{GetBiosDetails()} {im8()} {RetrieveBaseboardSerialNumber()} {GetComputerUID()}";
			if (hardwareInfo == "")
			{
				MessageBox.Show("错误：无法获取电脑序列号！请联系客服。");
			}
			else
			{
				Config.RegCode = GenerateSignature(hardwareInfo + Config.softCode);
			}
		}
		/// <summary>
		/// 从WMI获取指定类实例的指定属性值，返回首个非空结果。
		/// </summary>
		/// <param name="wmiClassName">WMI类名称。</param>
		/// <param name="propertyName">要查询的属性名。</param>
		/// <returns>首个非空属性值字符串，或在获取失败时返回空字符串。</returns>
		private static string RetrieveWmiProperty(string wmiClassName, string propertyName)
		{
			string value = "";
			foreach (ManagementObject instance in new ManagementClass(wmiClassName).GetInstances())
			{
				try
				{
					object propertyValue = instance[propertyName];

					if (propertyValue is null)
					{
						continue;
					}

					value = propertyValue.ToString();
					if (!string.IsNullOrEmpty(value))
					{
						break;
					}
				}
				catch
				{
					continue;
				}
			}

			return value;
		}

		/// <summary>
		/// 获取BIOS详细信息。
		/// </summary>
		/// <returns>包含多个BIOS属性值的字符串。</returns>
		public static string GetBiosDetails()
		{
			return $"Manufacturer:{RetrieveWmiProperty("Win32_BIOS", "Manufacturer")} SMBIOSBIOSVersion:{RetrieveWmiProperty("Win32_BIOS", "SMBIOSBIOSVersion")} IdentificationCode:{RetrieveWmiProperty("Win32_BIOS", "IdentificationCode")} SerialNumber:{RetrieveWmiProperty("Win32_BIOS", "SerialNumber")} ReleaseDate:{RetrieveWmiProperty("Win32_BIOS", "ReleaseDate")} Version:{RetrieveWmiProperty("Win32_BIOS", "Version")}";
		}
		/// <summary>
		/// 获取处理器ID。
		/// </summary>
		/// <returns>处理器ID字符串，或在获取失败时返回"unknow"。</returns>
		private static string im8()
		{
			try
			{
				using ManagementObjectCollection.ManagementObjectEnumerator enumerator = new ManagementClass("Win32_Processor").GetInstances().GetEnumerator();
				if (enumerator.MoveNext())
				{
					return ((ManagementObject)enumerator.Current).Properties["ProcessorId"].Value.ToString();
				}
			}
			catch
			{
			}

			return "unknow";
		}
		/// <summary>
		/// 获取主板序列号。
		/// </summary>
		/// <returns>主板序列号字符串，或在获取失败时返回"unknow"。</returns>
		private static string RetrieveBaseboardSerialNumber()
		{
			string serialNumber = "unknow";
			try
			{
				using ManagementObjectCollection.ManagementObjectEnumerator enumerator = new ManagementClass("Win32_BaseBoard").GetInstances().GetEnumerator();
				if (enumerator.MoveNext())
				{
					serialNumber = ((ManagementObject)enumerator.Current)["SerialNumber"].ToString();
				}
			}
			catch
			{
				// 可选：记录异常信息（例如使用AppLog.AddLog）
			}

			return serialNumber;
		}

		/// <summary>
		/// 将指定弹幕数据添加到关键用户弹幕数据列表中，如果该用户在设置中被标记为关键用户。
		/// </summary>
		/// <param name="data">待添加的弹幕数据对象。</param>
		public static void AddKeyUserDanmuData(DanmuData data)
		{
			if (data != null && Common.danmuSetting.KeyUser.IsEnabled)
			{
				string[] keyUserList = Common.danmuSetting.KeyUser.UserList.Split('\n', StringSplitOptions.RemoveEmptyEntries);
				if (keyUserList.Any(x => x.Trim() == data.UserNick))
				{
					Common.KeyUserDanmuData.Add(data);
				}
			}
		}
		/// <summary>
		/// 引导用户购买指定版本的应用程序。
		/// </summary>
		/// <param name="edition">要购买的版本类型。</param>
		internal static void PromptPurchase(int edition)
		{
			string message = "需要购买后使用！是否立即购买？";
			switch (edition)
			{
				case 1:
					message = "请购买高级版后操作！是否立即购买？";
					break;
				case 2:
					message = "请购买互动版后操作！是否立即购买？";
					break;
			}
			MessageBox.Show(message, "需要购买");
			//if (MessageBox.Show(message, "需要购买", MessageBoxButtons.OKCancel) == DialogResult.OK)
			//{
			//	OpenPurchasePage();
			//}
		}
		public static byte[] gzipDecompress(byte[] data)
		{
			try
			{
				MemoryStream memoryStream = new MemoryStream(data);
				GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress, leaveOpen: true);
				MemoryStream memoryStream2 = new MemoryStream();
				byte[] array = new byte[4096];
				while (true)
				{
					int num = gZipStream.Read(array, 0, array.Length);
					if (num <= 0)
					{
						break;
					}
					memoryStream2.Write(array, 0, num);
				}
				gZipStream.Close();
				gZipStream.Dispose();
				memoryStream.Close();
				memoryStream2.Position = 0L;
				array = memoryStream2.ToArray();
				memoryStream2.Close();
				return array;
			}
			catch
			{
				return null;
			}
		}

		public static void OpenUrl(string helpUrlChatBot)
		{
			Process.Start(new ProcessStartInfo(helpUrlChatBot) { UseShellExecute = true });

		}
	}
}
