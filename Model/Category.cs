using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLSaving.Model
{
    public class Category
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private ECategory kind;
        public ECategory Kind
        {
            get
            {
                return kind;
            }
            set
            {
                kind = value;
            }
        }
        public Category(string name = null, ECategory kind = ECategory.None)
        {
            Name = name;
            Kind = kind;
        }
    }
}
