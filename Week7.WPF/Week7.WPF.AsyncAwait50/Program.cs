using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Week7.WPF.AsyncAwait50
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch timer = Stopwatch.StartNew();

            //Coffee coffee = PourCoffee();
            //Console.WriteLine("Il caffè è pronto!");

            //Egg eggs = FryEggs(2);
            //Console.WriteLine("Le uova sono pronte!");

            //Bacon bacon = FryBacon(3);
            //Console.WriteLine("Il bacon è pronto!");

            //Toast toast = ToastBread(3);
            //Console.WriteLine("Il pane tostato è pronto");

            //tempo richiesto non asincrono: 21 sec circa

            Coffee coffee = PourCoffee();
            Console.WriteLine("Il caffè è pronto!");
            Egg eggs = await FryEggsAsync(2);
            Console.WriteLine("Le uova sono pronte!");
            Bacon bacon = await FryBaconAsync(3);
            Console.WriteLine("Il bacon è pronto!");
            Toast toast = await ToastBreadAsync(3);
            Console.WriteLine("Il pane tostato è pronto");

            Console.WriteLine("----------------");
            Console.WriteLine("La colazione è pronta");
            Console.WriteLine($"Tempo richiesto: {timer.ElapsedMilliseconds} ms");


            #region metodi sincroni

            Toast ToastBread(int v)
            {
                for (int i = 0; i < v; i++)
                {
                    Console.WriteLine($"Metto la {i + 1}a fetta di pane...");
                    Task.Delay(3000).Wait();
                    Console.WriteLine($"TING! La {i + 1}a fetta di pane è pronta");

                }

                Console.WriteLine("Tutto il pane è stato tostato");
                return new Toast();
            }

            Bacon FryBacon(int v)
            {
                Console.WriteLine("Metto la padella a scaldare...");
                Task.Delay(3000).Wait();
                Console.WriteLine($"Metto {v} fette di bacon in padella...");
                Task.Delay(3000).Wait();
                Console.WriteLine($"Impiatto il bacon...");

                return new Bacon();
            }

            Egg FryEggs(int v)
            {
                Console.WriteLine("Metto la padella a scaldare...");
                Task.Delay(3000).Wait(); //aspetta per tre secondi
                Console.WriteLine($"Metto {v} uova in padella...");
                Task.Delay(3000).Wait();
                Console.WriteLine($"Impiatto le uova...");

                return new Egg();
            }

            Coffee PourCoffee()
            {
                Console.WriteLine("Verso il caffè...");
                return new Coffee();
            }

            #endregion

            async Task<Egg> FryEggsAsync(int v)
            {
                Console.WriteLine("Metto la padella a scaldare...");
                await Task.Delay(3000); //aspetta per tre secondi
                Console.WriteLine($"Metto {v} uova in padella...");
                await Task.Delay(3000);
                Console.WriteLine($"Impiatto le uova...");

                return new Egg();
            }

            async Task<Bacon> FryBaconAsync(int v)
            {
                Console.WriteLine("Metto la padella a scaldare...");
                await Task.Delay(3000);
                Console.WriteLine($"Metto {v} fette di bacon in padella...");
                await Task.Delay(3000);
                Console.WriteLine($"Impiatto il bacon...");

                return new Bacon();
            }

            async Task<Toast> ToastBreadAsync(int v)
            {
                for (int i = 0; i < v; i++)
                {
                    Console.WriteLine($"Metto la {i + 1}a fetta di pane...");
                    await Task.Delay(3000);
                    Console.WriteLine($"TING! La {i + 1}a fetta di pane è pronta");

                }

                Console.WriteLine("Tutto il pane è stato tostato");
                return new Toast();
            }
        }
    }
}
