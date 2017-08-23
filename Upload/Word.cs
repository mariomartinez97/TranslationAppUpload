using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upload
{
    class Word
    {
        public String palabra
        {
            get;
            set;
        }

        public String traduccion
        {
            get;
            set;
        }

        public String definincion
        {
            get;
            set;
        }

        // Overload for the [] operator.
        // This allows for you to access a data member of the Word class as if the Word was an array.
        //
        // Example:
        //              Word w = new Word();
        //              String palabra = w[0];
        //
        //              The String palabra now holds w.palabra value.
        public String this[int _column]
        {
            get
            {
                switch (_column)
                {
                    case 0:
                        return palabra;
                        break;
                    case 1:
                        return traduccion;
                        break;
                    case 2:
                        return definincion;
                    default:
                        return palabra;
                        break;
                }
            }
        }

        // This function does the same thing as the overloaded [] operator above but
        // in function form.
        //
        // Example:
        //              Word w = new Word();
        //              String palabra = w.GetDataMemberByColumn(0);
        //
        //              The String palabra now holds w.palabra value.
        public String GetDataMemberByColumn(int _column)
        {
            switch (_column)
            {
                case 0:
                    return palabra;
                    break;
                case 1:
                    return traduccion;
                    break;
                case 2:
                    return definincion;
                default:
                    return palabra;
                    break;
            }
        }
    }
}
