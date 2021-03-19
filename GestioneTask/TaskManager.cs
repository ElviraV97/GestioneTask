using System;
using System.Collections.Generic;

namespace GestioneTask
{

    class TaskManager
    {

        private Dictionary<int, Task> _task = new Dictionary<int, Task>();
        private int _ID;


        internal string MostraTask(Formato formato)
        {
            string s = "";

            foreach (Task t in _task.Values)
                s += t.MostraTask(formato) + "\n";

            return s;
        }

        internal Task CreaTask(string descrizione, DateTime datascadenza, Importanza importanza)
        {
            Task t = new Task(++_ID, descrizione, datascadenza, importanza);

            _task.Add(t.ID, t);

            return t;
        }

        public bool Esiste(int id)
        {
            return _task.ContainsKey(id);
        }

        internal void Elimina(int id)
        {
            _task.Remove(id);
        }

        internal object VisTaskFiltrati(int import)
        {
            string s = "";

            foreach (Task t in _task.Values)
                if (t.Imp == (Importanza)import)
                    s += t.MostraTask(Formato.Plain) + "\n";

            return s;
        }

        internal bool EsisteImp(int imp)
        {
            foreach (Task t in _task.Values)
                if (t.Imp == (Importanza)imp)
                    return true;

            return false;
        }
    }
}