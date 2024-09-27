using Blazored.LocalStorage;
using Equitel_JoseGabrielCamacho.Data;
using Equitel_JoseGabrielCamacho.DataAccess;
using Equitel_JoseGabrielCamacho.Pages.Login;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System;
using System.Data;
using System.Globalization;
using System.Text;

namespace Equitel_JoseGabrielCamacho.Pages.PaginaBase
{
    public class PaginaBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected ILocalStorageService sessionStorage { get; set; }

        [Inject]
        protected NavigationManager NavManager { get; set; }

        protected bool mostrarInfo { get; set; } = false;

        protected int idUsuario, Rol;

        
        protected bool MostrarInformacion()
        {
            try
            {    
                if (idUsuario == 0)
                {
                    return false;
                }
                
                mostrarInfo = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                idUsuario = await sessionStorage.GetItemAsync<int>("IdUsuario");
                Rol = await sessionStorage.GetItemAsync<int>("Rol");
                if (MostrarInformacion()) return;
            }
            catch { }
        }

        protected override async Task OnAfterRenderAsync(bool render)                       
        {
            try
            {
                if (await sessionStorage.GetItemAsync<int>("IdUsuario") == 0)
                {
                    NavManager.NavigateTo("/login", true);
                    return;
                }

            }
            catch { }
        }

        protected static string ToMD5(string convertir)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(convertir);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes);
            }
        }

        protected void registrarAuditoria(string _Accion)
        {
            try
            {
                new AuditoriaDA().InsertOrUpdate(new Data.Auditoria { IdUsuario = idUsuario, Accion = _Accion, Fecha = DateTime.Now }, 1);
            }
            catch
            {

            }
        }

    }
}
