using System;
using Xamarin.Forms;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

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

            var statusa = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            if (statusa != PermissionStatus.Granted)
            {
                ///todo: Android Only
                //if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                //{
                //    //await DisplayAlert("Need location", "Gunna need that location", "OK");
                //}
                var statusGranted = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);
                statusa = statusGranted[Permission.Camera];
            }
            var statusb = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Microphone);
            if (statusb != PermissionStatus.Granted)
            {
                ///todo: Android Only
                //if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                //{
                //    //await DisplayAlert("Need location", "Gunna need that location", "OK");
                //}
                var statusGranted = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Microphone);
                statusb = statusGranted[Permission.Microphone];
            }







            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
            {

#pragma warning disable S1135 // Track uses of "TODO" tags
                ////todo: Android Only
                //if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))

#pragma warning disable S125 // Sections of code should not be commented out
                //{
                //    //await DisplayAlert("Need location", "Gunna need that location", "OK");
                //}
                var statusGranted = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);
#pragma warning restore S1135 // Track uses of "TODO" tags
#pragma warning restore S125 // Sections of code should not be commented out
                status = statusGranted[Permission.Camera];
            }

            var status2 = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Microphone);
            if (status2 != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
            {

#pragma warning disable S1135 // Track uses of "TODO" tags
                ////todo: Android Only
                //if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))

#pragma warning disable S125 // Sections of code should not be commented out
                //{
                //    //await DisplayAlert("Need location", "Gunna need that location", "OK");
                //}
                var statusGranted2 = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Microphone);
#pragma warning restore S1135 // Track uses of "TODO" tags
#pragma warning restore S125 // Sections of code should not be commented out
                status2 = statusGranted2[Permission.Microphone];
            }


            if (status == Plugin.Permissions.Abstractions.PermissionStatus.Granted && status2 == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
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
                    jwt: 'eyJraWQiOiJ2cGFhcy1tYWdpYy1jb29raWUtNTQ3ZTA2NWQxY2Q0NGIzOTgzZGM1NWY3ZjViMTIxMDUvN2YyM2NkLVNBTVBMRV9BUFAiLCJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiJqaXRzaSIsImlzcyI6ImNoYXQiLCJpYXQiOjE2NTA4OTI1NzMsImV4cCI6MTY1MDg5OTc3MywibmJmIjoxNjUwODkyNTY4LCJzdWIiOiJ2cGFhcy1tYWdpYy1jb29raWUtNTQ3ZTA2NWQxY2Q0NGIzOTgzZGM1NWY3ZjViMTIxMDUiLCJjb250ZXh0Ijp7ImZlYXR1cmVzIjp7ImxpdmVzdHJlYW1pbmciOnRydWUsIm91dGJvdW5kLWNhbGwiOnRydWUsInNpcC1vdXRib3VuZC1jYWxsIjpmYWxzZSwidHJhbnNjcmlwdGlvbiI6dHJ1ZSwicmVjb3JkaW5nIjp0cnVlfSwidXNlciI6eyJtb2RlcmF0b3IiOnRydWUsIm5hbWUiOiJnc2FsYXMiLCJpZCI6ImF1dGgwfDYxZTgzZjdhOTNlMDNmMDA3MDA3NmJjNSIsImF2YXRhciI6IiIsImVtYWlsIjoiZ3NhbGFzQHRydWVub3J0aC5wciJ9fSwicm9vbSI6IioifQ.X8Ap-WuN9lAH58ogT1rD467JCQmBSAd0vyCgqW8_QfjA-F7fYzHZMqPVv7eZb0L3J6E7udCInIupNY_dgreVH8-nBWdxyYm1f0KAuG-9A64BSEbIGyEl3ExrBbZH5ne2Ed90AHxgCqGATYg1_RnnyCwqs_cGjZ2dVCXa8wO94jDqGwDylFW6-uIYEvufMktwsJRbwBxTo20r0JkXSBnFQzadP29F1fnPfdq9sYqnZspchOh937G5U21yPgX5o-phL8EPi2twx9pFzLGESnCPqFJ6KfXhPtCVDAx65wy9N4upP4CpUnR0sYjxMrAH1YgwjkruuimJQB4ACi55U-55NA',
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
