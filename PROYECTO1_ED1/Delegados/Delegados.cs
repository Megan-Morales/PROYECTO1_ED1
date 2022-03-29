

using PROYECTO1_ED1.Models;

namespace Lab03_ED_2022.Comparison
{
    public delegate int Compare<T>(T a, T b);

    public class Delegados
    {
      

        public static int CompareString(string a, string b)
        {
            if (a != b)
            {
                if (a.CompareTo(b) < 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }

        public static int CompareInt(int a, int b)
        {
            if (a != b)
            {
                if (a > b)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {

                return 0;

            }
        }

        public static int CompararDPI(ModeloPaciente a, ModeloPaciente b)
        {

            if (a.DPI != b.DPI)
            {
                if (a.DPI < b.DPI)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }

        //public static int CompararSerial(ModeloPaciente a, ModeloPaciente b)
        //{
            

        //    if (a.SerialNo != b.SerialNo)
        //    {
        //        if (a.SerialNo.CompareTo(b.SerialNo) < 0)
        //        {
        //            return -1;
        //        }
        //        else
        //        {
        //            return 1;
        //        }
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        //public static int CompararEmail(ModeloPaciente a, ModeloPaciente b)
        //{
            

        //    if (a.Email != b.Email)
        //    {
        //        if (a.Email.CompareTo(b.Email) < 0)
        //        {
        //            return -1;
        //        }
        //        else
        //        {
        //            return 1;
        //        }
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        //public static ModeloPaciente CompararEmail(string a)
        //{
        //    ModeloPaciente parametro = new ModeloPaciente();
        //    parametro.Email = a;
        //    return parametro;
        //}
        //public static ModeloPaciente CompararSerial(string a)
        //{
        //    ModeloPaciente parametro = new ModeloPaciente();
        //    parametro.SerialNo = a;
        //    return parametro;
        //}

        public static ModeloPaciente CompararDPI(int a)
        {
            ModeloPaciente parametro = new ModeloPaciente();
            parametro.DPI = a;
            return parametro;
        }



    }


}

