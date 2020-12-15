using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o numero do concurso");
            string numeroConcurso = Console.ReadLine();

            if(string.IsNullOrEmpty (numeroConcurso))
            {
                numeroConcurso = "2103";
            }

            string url = @"http://www1.caixa.gov.br/loterias/loterias/megasena/megasena_pesquisa_new.asp?submeteu=sim&opcao=concurso&txtConcurso=" + numeroConcurso ;
            string html;
            //utilizando lib webclient
            using(WebClient wc = new WebClient())
            {
                //para validar a segurança
                wc.Headers["Cookie"] = "security=true";
                html = wc.DownloadString(url);
            }

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

        
        }   
    }
}
