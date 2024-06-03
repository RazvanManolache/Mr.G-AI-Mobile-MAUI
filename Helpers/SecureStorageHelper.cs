using MrG.Base.Data;
using MrG.Base.Enum;
using MrG.Base.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrG.Maui.Helpers
{
    internal class SecureStorageHelper : ISecureStorageHelper
    {
       
        public async Task<bool> WriteServer(Server server)
        {
            if(server == null)
            {
                return false;
            }
            await WriteVariableAsync(TypeAttribute, server.ServerType.ToString());
            await WriteVariableAsync(NameAttribute, server.Name);
            if(server.ServerType== ServerType.Local)
            {
                await WriteVariableAsync(IpAttribute, server.Ip);
            }
            if(server.ServerType == ServerType.Online)
            {
                await WriteVariableAsync(TokenAttribute, server.Token);
            }
                       
            
            return true;
        }

        public async Task<Server?> GetServer()
        {
            var type = await ReadVariableAsync(TypeAttribute);
            if(type == null)
            {
                return null;
            }
            if(!Enum.TryParse<ServerType>(type, out var serverType))
            {
                return null;
            }
            if (serverType == ServerType.Local)
            {
                var name = await ReadName();
                var ip = await ReadIP();
                if(name == null || ip == null)
                {
                    return null;
                }
                return new Server(serverType, name, ip);
            }
            if (serverType == ServerType.Online)
            {
                var name = await ReadName();
                var token = await ReadToken();
                if (name == null || token == null)
                {
                    return null;
                }
                return new Server(serverType, name, token);
            }
            return null;
            
        }

        private static string TypeAttribute = "ServerType";
        private static string NameAttribute = "ServerName";
        private static string IpAttribute = "ServerIp";
        private static string TokenAttribute = "ServerToken";

        public async Task<string?> ReadName()
        {
            return await ReadVariableAsync(NameAttribute);
        }


        public async Task<string?> ReadIP()
        {
            return await ReadVariableAsync(IpAttribute);
        }

        public async Task<string?> ReadToken()
        {
            return await ReadVariableAsync(TokenAttribute);
        }


        public bool DeleteVariable(string key)
        {
            try
            {
                SecureStorage.Remove(key);
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Failed to delete variable: {ex.Message}");
                return false;
            }
        }
        public async Task<string?> ReadVariableAsync(string key)
        {
            try
            {
                return await SecureStorage.GetAsync(key);
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Failed to read variable: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> WriteVariableAsync(string key, string? value)
        {
            try
            {
                await SecureStorage.SetAsync(key, value);
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Failed to write variable: {ex.Message}");
                return false;
            }
        }
    }
}
