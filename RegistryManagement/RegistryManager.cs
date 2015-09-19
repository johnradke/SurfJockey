using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfJockey.RegistryManagement
{
    public class RegistryManager
    {
        public void MakeMeDefault(string applicationPath)
        {
            CreateProgId();
            CreateProtocolAssociations();
            RegisterApplication();
            MakeDefault();
        }

        private void MakeDefault()
        {
            // [HKEY_CURRENT_USER\Software\Clients\StartMenuInternet] @="app name"
            // [HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.htm\OpenWithProgids] => add progid, type=None
            // [HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.htm\UserChoice] => set "Progid"=this one
            // [HKEY_CURRENT_USER\Software\Classes\.htm] @="prog id"
            // same for .html, .shtml, .xht, .xhtml

            // [HKEY_CURRENT_USER\Software\Microsoft\Windows\Shell\Associations\UrlAssociations\ftp\UserChoice] => set "Progid=this one
            // [HKEY_CURRENT_USER\Software\Classes\ftp\shell\open\command] = "commandline.exe \"%1\""
            // same for http, https
            throw new NotImplementedException();
        }

        private void RegisterApplication()
        {
            // under HKEY_LOCAL_MACHINE\SOFTWARE\RegisteredApplications, create Litware Player = Software\Litware\LitwarePlayer\Capabilities
            throw new NotImplementedException();
        }

        private void CreateProtocolAssociations()
        {
            // create HKLM/SOFTWARE/Clients/StartMenuInternet/urlboss
            // create HKLM/SOFTWARE/Clients/StartMenuInternet/urlboss/Capabilities/
            // create HKLM/SOFTWARE/Clients/StartMenuInternet/urlboss/Capabilities/URLAssociations (ftp,http,https)
            throw new NotImplementedException();
        }

        private void CreateProgId()
        {
            // HKEY_LOCAL_MACHINE/SOFTWARE/Classes/refURL (or whatever)

            throw new NotImplementedException();
        }

        //public void GetAllApplications
    }
}
