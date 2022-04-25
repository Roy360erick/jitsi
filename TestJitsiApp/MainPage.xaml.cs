using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace TestJitsiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Camera>();
            }

            var statusb = await Permissions.CheckStatusAsync<Permissions.Microphone>();

            if (statusb != PermissionStatus.Granted)
            {
                statusb = await Permissions.RequestAsync<Permissions.Microphone>();
            }

            if (status == PermissionStatus.Granted && statusb == PermissionStatus.Granted)
            {
                //webview.Source = "https://jitsioriginalframe.netlify.app/";
                var localHtml = new HtmlWebViewSource();
                localHtml.Html = @"<html>
                                    <head>
                                        <script src='https://8x8.vc/external_api.js' async></script>
                                        <style>
                                            html,
                                            body,
                                            #jaas-container {
                                                height: 100%;
                                            }
                                        </style>
                                        <script type='text/javascript'>
                                            let api;
                                            const initIframeAPI = () => {
                                                const domain = '8x8.vc';
                                                const options = {
                                                    roomName: 'vpaas-magic-cookie-547e065d1cd44b3983dc55f7f5b12105/TestJitsi',
                                                    jwt: 'eyJhbGciOiJSUzI1NiIsImtpZCI6InZwYWFzLW1hZ2ljLWNvb2tpZS01NDdlMDY1ZDFjZDQ0YjM5ODNkYzU1ZjdmNWIxMjEwNS83NzMwMjMiLCJ0eXAiOiJKV1QifQ.eyJhdWQiOiJqaXRzaSIsImlzcyI6ImNoYXQiLCJleHAiOjE2NTA5MzIzNTksIm5iZiI6MTY1MDkwMzU1OSwicm9vbSI6IkppdHNpVGVzdFJvb20iLCJzdWIiOiJ2cGFhcy1tYWdpYy1jb29raWUtNTQ3ZTA2NWQxY2Q0NGIzOTgzZGM1NWY3ZjViMTIxMDUiLCJjb250ZXh0Ijp7InVzZXIiOnsibW9kZXJhdG9yIjoiZmFsc2UiLCJpZCI6ImIxYzJiNzkxLWNkOWItNDAyNC05ZTE2LTI4Mjc0OGZiMTM2NCIsIm5hbWUiOiJEYW5pZWwgMTIzIiwiZW1haWwiOiIiLCJhdmF0YXIiOiIifSwiZmVhdHVyZXMiOnsibGl2ZXN0cmVhbWluZyI6ImZhbHNlIiwicmVjb3JkaW5nIjoiZmFsc2UiLCJvdXRib3VuZC1jYWxsIjoiZmFsc2UiLCJ0cmFuc2NyaXB0aW9uIjoiZmFsc2UifX19.QfVsBXQ4JtHOoAAwRZcD7TzOUKsNuUdx2m0dqkw_vF4x3ftw_F3-4phdsjyldbOQFiCe53DE5qoBrh9vGzVQGjCkRqSejzJwOXP8GBp690d8ea22qCM_OTw3TlSxaxTuCJTtCDmfcjjWijegt-1YJRyFVxdLB7axUAQUNbczxfLDVv5BftyrUGNRx2Dgm-zUtnwNazqLI1qpmf3JBkPhCcNf3tsksYvz7YL2C0dVlg8NCncv0F-rI6rsTL0QfhlkqlDnI-aJqndzIYFOfZA8YPf_0oiF06sjJr3yKWiCwyjJft1l60rezmtW_j3RR1A__AZte0cf1JX3WLS61BkOZg',
                                                    width: '100%',
                                                    height: '100%',
                                                    parentNode: document.querySelector('#jaas-container')
                                                };

                                                api = new JitsiMeetExternalAPI(domain, options);
                                            }
                                            window.onload = () => {
                                                initIframeAPI();
                                            }
                                        </script>
                                    </head>

                                    <body>
                                        <div id='jaas-container' />
                                    </body>

                                </html>";
                webview.Source = localHtml;
            }
            else
            {
                webview.Source = "https://www.google.com/";
            }
            IsBusy = false;
            button1.IsVisible = false;
        }
    }
}
