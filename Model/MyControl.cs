using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class MyControl
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        string cLocation;

        public string CLocation
        {
            get { return cLocation; }
            set { cLocation = value; }
        }


        string cFont;

        public string CFont
        {
            get { return cFont; }
            set { cFont = value; }
        }

        string cColor;

        public string CColor
        {
            get { return cColor; }
            set { cColor = value; }
        }
    }
}
