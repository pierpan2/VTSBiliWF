using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using VTS;
using VTS.Models;
using VTS.Networking;
using VTS.Networking.Impl;
using VTS.Models.Impl;

namespace VTSBiliWF
{
    internal class Sender : VTSPlugin
    {
        public Sender()
        {
            this._pluginAuthor = "PierPan";
            this._pluginName = "VTSBili";
            this.Initialize(
                new VTSWebSocket(),
                new WebSocketImpl(),
                new JsonUtilityImpl(),
                new TokenStorageImpl(),
                () => { Debug.WriteLine("!!!Connected"); },
                () => { Debug.WriteLine("!!!Disconnected"); },
                () => { Debug.WriteLine("!!!Error"); });
        }
        public void PrintAPIStats(Label label)
        {
            GetStatistics(
                (r) => { label.Text = new JsonUtilityImpl().ToJson(r); },
                (e) => {}
            );
        }

    }
}
