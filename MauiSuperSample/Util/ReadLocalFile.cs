using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MauiSuperSample.Model;

namespace MauiSuperSample.Util
{
    internal class ReadLocalFile
    {
        public async Task<List<Monkey>> GetMonkeys()
        {
            //Ler arquivo no resources do projeto
            using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            var monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);

            return monkeyList;

            //Atencão
            //Não esquecer de inincializar o service no builder // MonkeyService = ReadLocalFile
            //builder.Services.AddSingleton<MonkeyService>(); 

            //Utilização
            //MonkeyService monkeyService;

            //public MonkeysViewModel(MonkeyService monkeyService)
            //{
            //    this.monkeyService = monkeyService;
            //}

        }
    }
}
