using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tripadvisor.model
{
    public class Evaluation
    {
        string comment;
        int note;
        User user;

        public Evaluation(string comment, int note, User user)
        {
            this.comment = comment;
            this.note = note;
            this.user = user;
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }
        }

        public int Note
        {
            get
            {
                return this.note;
            }
        }

        public User User { get => user; }

        public override bool Equals(object obj)
        {
            Evaluation aux = obj as Evaluation;
            return aux != null && this.comment.Equals(aux.Comment) &&
                this.note == aux.Note && this.user.Equals(aux.User);
        }
    }
}
