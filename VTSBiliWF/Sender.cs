using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using VTS;
using VTS.Models;
using VTS.Networking;
using VTS.Networking.Impl;
using VTS.Models.Impl;

namespace VTSBiliWF
{
    internal class Sender : VTSPlugin
    {
        private CancellationTokenSource cancelSource;

        public string info = "";

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

            cancelSource = new CancellationTokenSource();
            Task.Run(SocketUpdate, cancelSource.Token);
        }
        public void PrintAPIStats()
        {
            GetStatistics(
                (r) => { Debug.WriteLine( new JsonUtilityImpl().ToJson(r)); },
                (e) => {}
            );
        }
        public void ActivateExpression(string expressionName)
        {
            string text = "";
            GetExpressionStateList(
                (r) => {
                    text = new JsonUtilityImpl().ToJson(r);
                    ExpressionData expression = new List<ExpressionData>(r.data.expressions).Find((e) => { return e.file.ToLower().Contains(expressionName.ToLower()); });
                    if (expression != null)
                    {
                        SetExpressionState(expression.file, true,
                            (x) => { text = new JsonUtilityImpl().ToJson(x); },
                            (e2) => { text = e2.data.message; });
                    }
                    else
                    {
                        throw new System.Exception("No Expression with " + expressionName + " in the file name was found.");
                    }
                },
                (e) => { text = e.data.message; }
            );
            Debug.WriteLine(text);
        }
        private async Task SocketUpdate()
        {
            try
            {
                while (true)
                {
                    base.Socket.Update();
                    await Task.Delay(2);
                }
            }
            catch (Exception)
            {
            }
        }
        public void Close()
        {
            // cancelSource.Cancel();
            base.Socket.Close();
        }

    }
}
