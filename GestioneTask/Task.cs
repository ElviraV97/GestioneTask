using System;

namespace GestioneTask
{
    enum Importanza
    {
        Basso = 1,
        Medio,
        Alto
    }
    enum Formato
    {
        Plain,
        CSV
    }

    class Task
    {
        public int ID { get; }
        public string Descrizione { get; }
        private DateTime DataScadenza { get; }
        public Importanza Imp { get; }

        public Task(int id, string descrizione, DateTime datascadenza, Importanza importanza)
        {
            ID = id;
            Descrizione = descrizione;
            DataScadenza = datascadenza;
            Imp = importanza;
        }





        public string MostraTask(Formato formato)
        {
            switch (formato)
            {
                case Formato.Plain:
                    return $"Task: {ID}, Descrizione: {Descrizione}, Data di scadenza: {DataScadenza}, Importanza: {Imp}";
                case Formato.CSV:
                    return $"{ID};{Descrizione};{DataScadenza};{Imp}";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}