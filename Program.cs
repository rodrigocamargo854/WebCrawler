using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;


//resultado da megasena com json
namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o numero do concurso");
            string numeroConcurso = Console.ReadLine();

            if (string.IsNullOrEmpty(numeroConcurso))
            {
                numeroConcurso = "2102";
            }

            string url = @"http://loterias.caixa.gov.br/wps/portal/loterias/landing/megasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA0sjIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQE-F4ca/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO6H80AU71KG7J0072/res/id=buscaResultado/c=cacheLevelPage//p=concurso=" + numeroConcurso;
            string json;
            //utilizando lib webclient
            using (WebClient wc = new WebClient())
            {
                //para validar a segurança
                wc.Headers["Cookie"] = "security=true";
                //download da url (html)
                json = wc.DownloadString(url);

            }

            Resultado resultadoMegasena = JsonConvert.DeserializeObject<Resultado>(json);
            //limpeza do html
            // html = html.Replace("<span class=\"num_sorteio\"><ul>",""); //retira o span
            // html = html.Replace("</ul></span>",""); //retira o span
            // html = html.Replace("</li>",""); //retira o span

            // string[] vet = Regex.Split(html, "<li>");
            // List<int> resultado = new List<int>();

            // resultado.Add(int.Parse(vet[1]));
            // resultado.Add(int.Parse(vet[2]));
            // resultado.Add(int.Parse(vet[3]));
            // resultado.Add(int.Parse(vet[4]));
            // resultado.Add(int.Parse(vet[5]));
            // resultado.Add(int.Parse(vet[6].Substring(0,2)));

            // foreach (var item in resultado)
            // {
            //     Console.WriteLine(item);
            // }
            var resultado = resultadoMegasena.listaDezenas;
            foreach (var item in resultado)
            {
                Console.WriteLine(item);
            }
           


        }
    }
}
