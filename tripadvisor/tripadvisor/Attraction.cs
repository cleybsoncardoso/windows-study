using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tripadvisor.model
{
    public class Attraction
    {
        private string name;
        private string local;
        private List<Evaluation> evaluations;

        public Attraction(string name, string local)
        {
            this.name = name;
            this.local = local;
            this.evaluations = new List<Evaluation>();
        }

        public string Name { get => name; }
        public string Local { get => local; }
        public List<Evaluation> Evaluations { get => evaluations; }

        public override bool Equals(object obj)
        {
            Attraction aux = obj as Attraction;
            return aux != null && this.name.Equals(aux.Name) && this.local.Equals(aux.Local) && this.evaluations.SequenceEqual(aux.Evaluations);
        }

    }
}
