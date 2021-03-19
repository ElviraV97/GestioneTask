using System;
using System.IO;

namespace GestioneTask
{
    class Program
    {
        private static TaskManager taskmanager = new TaskManager();

        static void Main(string[] args)
        {
            Console.WriteLine("Gestione Task");

            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Visualizza task");
                Console.WriteLine("2. Aggiungi un nuovo task");
                Console.WriteLine("3. Elimina Task");
                Console.WriteLine("4. Visualizza task per importanza");
                Console.WriteLine("5. Salva");
                Console.WriteLine("0. Esci");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        VisualizzaTask();
                        break;
                    case '2':
                        AggiungiTask();
                        break;
                    case '3':
                        EliminaTask();
                        break;
                    case '4':
                        VisualizzaTaskFiltrati();
                        break;
                    case '5':
                        Salva();
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (true);
        }

        private static void Salva()
        {
            const string fileName = @"task.csv";
            Formato formato = Formato.CSV;

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(taskmanager.MostraTask(formato));
            }
        }

        private static void VisualizzaTaskFiltrati()
        {
            int imp;
            do
            {
                Console.Write("\nInserisci importanza (1. Basso, 2. Medio, 3. Alto): ");
                imp = Convert.ToInt32(Console.ReadLine());
            } while (!(imp == 1 || imp == 2 || imp == 3));

            if (taskmanager.EsisteImp(imp))
            {
                Console.WriteLine($"I task con importanza {imp} sono \n{taskmanager.VisTaskFiltrati(imp)}");
            }
            else
                Console.WriteLine($"Non esistono task con importanza {imp}");


        }

        private static void EliminaTask()
        {
            Console.WriteLine();
            int id;
            do
                Console.Write("Numero task da eliminare: ");
            while (!int.TryParse(Console.ReadLine(), out id));

            if (taskmanager.Esiste(id))
            {
                taskmanager.Elimina(id);
            }
            else
                Console.WriteLine("Task inesistente");
        }

        private static void AggiungiTask()
        {
            Console.Write("\nDescrizione task: ");
            string descr = Console.ReadLine();

            DateTime datascad;
            do
                Console.Write("Inserisci data di scadenza (gg/mm/aaaa): ");
            while (!DateTime.TryParse(Console.ReadLine(), out datascad));

            int imp;
            do
            {
                Console.Write("Inserisci importanza (1. Basso, 2. Medio, 3. Alto): ");
                imp = Convert.ToInt32(Console.ReadLine());
            } while (!(imp == 1 || imp == 2 || imp == 3));


            if (datascad >= DateTime.Today)
            {
                Task t = taskmanager.CreaTask(descr, datascad, (Importanza)Enum.ToObject(typeof(Importanza), imp));
                Console.WriteLine($"Task {t.ID}, {t.Descrizione}, inserito");
            }
            else
                Console.WriteLine("La data di scadenza inserita non è valida");
        }

        private static void VisualizzaTask()
        {
            Console.WriteLine("\nVisualizzazione dei task inseriti");
            Console.WriteLine(taskmanager.MostraTask(Formato.Plain));
        }
    }
}
