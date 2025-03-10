﻿using Blazored.SessionStorage;
using System.Text.Json;
using System.Text;
using CursosControllador.Entidades;

namespace CursosFront.Extensiones
{
    public static class SesionStorageExtension
    {
        public static async Task GuardarStorage<T>(this ISessionStorageService sessionStorageService,string key, T item) where T:class
        {
            var itemJson=JsonSerializer.Serialize(item);
            await sessionStorageService.SetItemAsStringAsync(key, itemJson);
        }

        public static async Task<T?> ObtenerStorage<T>(this ISessionStorageService sessionStorageService, string key) where T : class
        {
            var itemJson = await sessionStorageService.GetItemAsStringAsync(key);
            return itemJson != null ? JsonSerializer.Deserialize<T>(itemJson) : null;
        }

        public static async Task RemoverStorage(this ISessionStorageService sessionStorageService, string key)
        {
            await sessionStorageService.RemoveItemAsync(key);
        }
    }
}
