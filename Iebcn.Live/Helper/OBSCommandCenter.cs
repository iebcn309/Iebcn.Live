using System.Runtime.ExceptionServices;
using Iebcn.Live.Controls;
using Iebcn.Live.ViewModel;
using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Communication;
using OBSWebsocketDotNet.Types;
namespace Iebcn.Live.Helper
{
	public class OBSCommandCenter
    {
        private static OBSCmdWindow _obsCmdWindow;
        private static OBSCmd _obsCommandSettings;
        private static OBSWebsocket _obsWebsocket;

        public static UILog Log;
        public static Dictionary<string, List<string>> SceneItems;
        public static List<DanmuData> DanmuDataCache;
        public static List<string> SceneNames;

        public static void ShowOBSCmdWindow()
        {
            if (_obsCmdWindow == null || _obsCmdWindow.IsClosed)
            {
                _obsCmdWindow = new OBSCmdWindow();
            }
            _obsCmdWindow.Show();
            _obsCmdWindow.Activate();
        }
        public static void LogInfo(string string_0)
        {
            Log.Content += DateTime.Now.ToString("hh:mm:ss") + "：" + string_0 + "\r\n";
        }

        public static void ClearDanmuCache()
        {
            if (DanmuDataCache != null)
            {
                DanmuDataCache.Clear();
                LogInfo("已清空缓存");
            }
        }
        public static void ConnectOBSWebSocket()
        {
            if (_obsWebsocket == null)
            {
                _obsWebsocket = new OBSWebsocket();
            }
            _obsWebsocket.WSTimeout = TimeSpan.FromSeconds(8.0);
            _obsWebsocket.Connected += OnOBSConnected;
            _obsWebsocket.Disconnected += OnOBSDisconnected;
            string url = $"ws://{_obsCommandSettings.Host}:{_obsCommandSettings.Port}";
            try
            {
                _obsWebsocket.ConnectAsync(url, _obsCommandSettings.Pass);
            }
            catch (Exception ex)
            {
                LogInfo($"连接OBS WebSocket时发生错误：{ex.Message}");
            }
        }

        private static void OnOBSConnected(object object_0, object object_1)
        {
            LogInfo("连接OBS成功");
            if (_obsCmdWindow != null && !_obsCmdWindow.IsClosed)
            {
                _obsCmdWindow.UpdateConnState(success: true);
            }
            if (SceneItems == null)
            {
                SceneItems = new Dictionary<string, List<string>>();
            }
            SceneItems.Clear();
            GetSceneListInfo sceneList = _obsWebsocket.GetSceneList();
            SceneNames.Clear();
            foreach (SceneBasicInfo scene in sceneList.Scenes)
            {
                SceneItems.Add(scene.Name, GetSceneItems(scene.Name));
                SceneNames.Add(scene.Name);
            }
        }
        private static void OnOBSDisconnected(object object_0, ObsDisconnectionInfo obsDisconnectionInfo_0)
        {
            if (_obsCmdWindow != null && !_obsCmdWindow.IsClosed)
            {
                _obsCmdWindow.UpdateConnState(success: false);
            }
            LogInfo("已断开连接 " + obsDisconnectionInfo_0.DisconnectReason);
        }
        public static async void Uou()
        {
            if (Common.VIPLevel < 2)
            {
                return;
            }
            if (DanmuDataCache == null)
            {
                DanmuDataCache = new List<DanmuData>();
            }
            Exception obj4;
            while (true)
            {
                Exception obj = null;
                int num = 0;
                try
                {
                    try
                    {
                        if (!_obsCommandSettings.Enabled || _obsWebsocket == null || !_obsWebsocket.IsConnected || _obsCommandSettings.SavedCmdList.Count <= 0 || DanmuDataCache == null || DanmuDataCache.Count <= 0)
                        {
                            goto end_IL_0083;
                        }
                        DanmuData ixsS = DanmuDataCache.LastOrDefault();
                        DanmuDataCache.Remove(ixsS);
                        OBSCmdItem oBSCmdItem = null;
                        int int_ = 1;
                        if (ixsS.Type == DanmuType.Gift)
                        {
                            oBSCmdItem = _obsCommandSettings.SavedCmdList.FirstOrDefault((x) => x.DType == ixsS.Type && (ixsS.GiftName == x.GiftName || x.GiftName == ""));
                            if (_obsCommandSettings.GiftExcuteByCount)
                            {
                                int_ = ixsS.GiftCount;
                            }
                        }
                        else if (ixsS.Type != 0)
                        {
                            if (ixsS.Type == DanmuType.Like)
                            {
                                oBSCmdItem = _obsCommandSettings.SavedCmdList.FirstOrDefault((x) => x.DType == DanmuType.Like);
                            }
                        }
                        else
                        {
                            oBSCmdItem = _obsCommandSettings.SavedCmdList.FirstOrDefault((x) => x.DType == ixsS.Type && ixsS.PureMsg == x.ChatWord);
                        }
                        if (oBSCmdItem == null)
                        {
                            goto end_IL_0083;
                        }
                        await To1(oBSCmdItem, int_);
                        goto end_IL_005b;
                    end_IL_0083:;
                    }
                    catch
                    {
                        goto end_IL_005b;
                    }
                    num = 1;
                end_IL_005b:;
                }
                catch (Exception obj3)
                {
                    obj = obj3;
                }
                await Task.Delay(500);
                obj4 = obj;
                if (obj4 != null)
                {
                    Exception obj5 = obj4 as Exception;
                    if (obj5 == null)
                    {
                        break;
                    }
                    ExceptionDispatchInfo.Capture(obj5).Throw();
                }
                if (num == 1)
                {
                }
            }
            throw obj4;
        }
        public static void EoL(DanmuData danmuData_0)
        {
            bool flag = false;
            if (!_obsCommandSettings.Enabled)
            {
                return;
            }
            if (danmuData_0.Type == DanmuType.Gift && _obsCommandSettings.SavedCmdList.Any((x) => x.DType == DanmuType.Gift && (danmuData_0.GiftName == x.GiftName || x.GiftName == "")))
            {
                flag = true;
            }
            if (danmuData_0.Type == DanmuType.Like && _obsCommandSettings.SavedCmdList.Any((x) => x.DType == DanmuType.Like))
            {
                flag = true;
            }
            if (danmuData_0.Type == DanmuType.Chat && _obsCommandSettings.SavedCmdList.Any((x) => x.DType == DanmuType.Chat && danmuData_0.PureMsg == x.ChatWord))
            {
                flag = true;
            }
            if (flag)
            {
                if (DanmuDataCache == null)
                {
                    DanmuDataCache = new List<DanmuData>();
                }
                DanmuDataCache.Add(danmuData_0);
                if (DanmuDataCache.Count > _obsCommandSettings.CacheMax)
                {
                    DanmuDataCache.RemoveAt(0);
                }
            }
        }
        public static async Task To1(OBSCmdItem obscmdItem_0, int int_0 = 1)
        {
            LogInfo("执行-> " + obscmdItem_0.CmdDesc + " 次数：" + int_0);
            for (int i = 0; i < int_0; i++)
            {
                vom(obscmdItem_0.Sence, obscmdItem_0.SenceItem, obscmdItem_0.Cmd1Open);
                await Task.Delay((int)(1000.0 * obscmdItem_0.CmdLastSeconds));
                vom(obscmdItem_0.Sence, obscmdItem_0.SenceItem, obscmdItem_0.Cmd2Open);
            }
        }
        private static void vom(string string_0, string string_1, bool bool_0)
        {
            try
            {
                if (_obsWebsocket != null && _obsWebsocket.IsConnected)
                {
                    SceneItemDetails sceneItemDetails = _obsWebsocket.GetSceneItemList(string_0).FirstOrDefault((x) => x.SourceName == string_1);
                    if (sceneItemDetails != null)
                    {
                        _obsWebsocket.SetSceneItemEnabled(string_0, sceneItemDetails.ItemId, bool_0);
                    }
                }
                else
                {
                    LogInfo("OBS未连接");
                }
            }
            catch
            {
            }
        }

        private static List<string> GetSceneItems(string string_0)
        {
            List<string> list = new List<string>();
            foreach (SceneItemDetails sceneItem in _obsWebsocket.GetSceneItemList(string_0))
            {
                list.Add(sceneItem.SourceName);
            }
            return list;
        }

        static OBSCommandCenter()
        {
            _obsCmdWindow = null;
            Log = new UILog();
            _obsCommandSettings = Common.danmuSetting.OBSCmd;
            DanmuDataCache = null;
            SceneNames = new List<string>();
        }
    }

}