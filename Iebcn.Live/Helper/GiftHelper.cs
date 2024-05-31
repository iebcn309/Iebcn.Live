using Iebcn.Live.ViewModel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;

namespace Iebcn.Live.Helper
{
	public sealed class GiftHelper
	{
		private static List<GiftInfo> uFs;
		public static List<GiftInfo> giftList
		{
			get
			{
				if (uFs == null)
				{
					uFs = tfz();
				}
				return uFs;
			}
		}
		private static List<GiftInfo> tfz()
		{
			List<GiftInfo> list = new List<GiftInfo>();
			foreach (JToken item2 in JsonConvert.DeserializeObject<JObject>(Resource1.encGifts)["data"]["pages"] as JArray)
			{
				JArray jArray = item2["gifts"] as JArray;
				if (jArray.Count() <= 0)
				{
					continue;
				}
				using (IEnumerator<JToken> enumerator2 = jArray.GetEnumerator())
				{
					GiftInfo obj;
					object obj2;
					GiftInfo item;
					for (; enumerator2.MoveNext(); obj.Image = (string)obj2, item = obj, list.Add(item))
					{
						JToken current = enumerator2.Current;
						obj = new GiftInfo
						{
							GiftId = current.Value<int>("GiftId"),
							Name = current.Value<string>("Name")
						};
						JToken jToken = current["image"]["url_list"][0];
						if (jToken == null)
						{
							obj2 = null;
						}
						else
						{
							obj2 = jToken.ToString();
							if (obj2 != null)
							{
								continue;
							}
						}
						obj2 = "";
					}
				}
			}

			return list;
		}

		public static List<GiftInfo> Search(string query)
		{
			return giftList.Where((GiftInfo x) => x.Name.Contains(query)).ToList();
		}

		public static List<GiftInfo> GetGiftInfoByIds(List<int> ids)
		{
			return giftList.Where((GiftInfo x) => ids.Contains(x.GiftId)).ToList();
		}

        public static GiftInfo GetGiftById(int id)
        {
            return giftList.FirstOrDefault((GiftInfo x) => id == x.GiftId);
        }
    }
	internal sealed class AesEncryption
	{
		private static Aes GetAes()
		{
			Aes aes = Aes.Create();
			aes.Key = Encoding.UTF8.GetBytes("TestTestTestTest");
			aes.IV = Encoding.UTF8.GetBytes("1234567812345678");
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			aes.BlockSize = 128;
			return aes;
		}

		public static string Encrypt(string string_0)
		{
			string result = string.Empty;
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			result = Convert.ToBase64String(GetAes().CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
			return result;
		}

		public static string Decrypt(string string_0)
		{
			string result = string.Empty;
			byte[] array = Convert.FromBase64String(string_0);
			byte[] bytes = GetAes().CreateDecryptor().TransformFinalBlock(array, 0, array.Length);
			result = Encoding.UTF8.GetString(bytes);
			return result;
		}


	}

}
