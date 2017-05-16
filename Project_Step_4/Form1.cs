using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
namespace Project_Step_4
{
    public partial class Form1 : Form
    {
        int temp_meanfun;
        bool yarab = false;
        const char semi = ':';
        List<string> intVariables = new List<string>();
        List<intvar> intVariabless = new List<intvar>();
        List<intvar> intVariablesval = new List<intvar>();
        //   string[] intVariable;
        List<arrays> arrayIntegar = new List<arrays>();
        //   string[] intVariable;
        List<string> floatVariables = new List<string>();
        //   string[] floatVariable;
        List<arrays> arrayFloat = new List<arrays>();
        //   arrays[] arrayFloat;
        List<arrays> arrayBool = new List<arrays>();
        //   arrays[] arrayFloat;
        List<string> stringVariables = new List<string>();
        //   string[] stringVariable;
        List<arrays> arrayString = new List<arrays>();
        //   arrays[] arrayFloat;
      //  List<string> functionVariables = new List<string>();
        //   string[] functionVariable;
        List<string> switchVariables = new List<string>();
        //   string[] switchVariable;
        List<string> boolVariables = new List<string>();
        //   string[] stringVariable;
        List<string> allGrammar = new List<string>();
        List<string> localgrammer = new List<string>();
        List<string> globalgrammerchak = new List<string>();
        List<string> grammer = new List<string>();
     //   List<function> functionVoid= new List<function>();
       
        //   string[] intVariable;
     //   List<arrays> funArrayIntegar = new List<arrays>();
        //   string[] intVariable;
     //   List<string> funFloatVariables = new List<string>();
        //   string[] floatVariable;
      //  List<arrays> funArrayFloat = new List<arrays>();
        //   arrays[] arrayFloat;
     //   List<string> funStringVariables = new List<string>();
        //   string[] stringVariable;
    //    List<arrays> funArrayString = new List<arrays>();
        //   arrays[] arrayFloat;
        List<function> func = new List<function>();
        List<string> funIntVariables = new List<string>();
        List<string> funFloatVariables = new List<string>();
        List<string> funStringVariables = new List<string>();
        List<string> funBoolVariables = new List<string>();
        
        bool runstop = false;
        bool bugrun = false;
        bool txtel8ur = false;
        void clear()
        {
            txtErorr.Clear();
            allGrammar.Clear();
            intVariables.Clear();
            arrayIntegar.Clear();
            floatVariables.Clear();
            arrayFloat.Clear();
            stringVariables.Clear();
            arrayString.Clear();
            switchVariables.Clear();
            boolVariables.Clear();
            func.Clear();
            funIntVariables.Clear();
            funFloatVariables.Clear();
            funStringVariables.Clear();
            funBoolVariables.Clear();
            localgrammer.Clear();
            globalgrammerchak.Clear();
           
        }
        [DllImport("kernel32.dll")]
        
      //  [DllImport("kernel32.dll", SetLastError = true)]
     //   [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();






        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;













        /// <summary>
        /// Contains information about a console screen buffer.
        /// </summary>
        private struct ConsoleScreenBufferInfo
        {
            /// <summary> A CoOrd structure that contains the size of the console screen buffer, in character columns and rows. </summary>
            internal CoOrd dwSize;
            /// <summary> A CoOrd structure that contains the column and row coordinates of the cursor in the console screen buffer. </summary>
            internal CoOrd dwCursorPosition;
            /// <summary> The attributes of the characters written to a screen buffer by the WriteFile and WriteConsole functions, or echoed to a screen buffer by the ReadFile and ReadConsole functions. </summary>
            internal Int16 wAttributes;
            /// <summary> A SmallRect structure that contains the console screen buffer coordinates of the upper-left and lower-right corners of the display window. </summary>
            internal SmallRect srWindow;
            /// <summary> A CoOrd structure that contains the maximum size of the console window, in character columns and rows, given the current screen buffer size and font and the screen size. </summary>
            internal CoOrd dwMaximumWindowSize;
        }

        /// <summary>
        /// Defines the coordinates of a character cell in a console screen buffer. 
        /// The origin of the coordinate system (0,0) is at the top, left cell of the buffer.
        /// </summary>
        private struct CoOrd
        {
            /// <summary> The horizontal coordinate or column value. </summary>
            internal Int16 X;
            /// <summary> The vertical coordinate or row value. </summary>
            internal Int16 Y;
        }

        /// <summary>
        /// Defines file type values for use when retrieving the type of a specified file.
        /// </summary>
        private enum FileType
        {
            /// <summary> Either the type of the specified file is unknown, or the function failed. </summary>
            Unknown,
            /// <summary> The specified file is a disk file. </summary>
            Disk,
            /// <summary> The specified file is a character file, typically an LPT device or a console. </summary>
            Char,
            /// <summary> The specified file is a socket, a named pipe, or an anonymous pipe. </summary>
            Pipe
        };

        /// <summary>
        /// Gets a value that indicates whether the error output stream has been redirected from the standard error stream.
        /// </summary>
        internal static Boolean IsErrorRedirected
        {
            get { return FileType.Char != GetFileType(GetStdHandle(StdHandle.StdErr)); }
        }

        /// <summary>
        /// Gets a value that indicates whether input has been redirected from the standard input stream.
        /// </summary>
        internal static Boolean IsInputRedirected
        {
            get { return FileType.Char != GetFileType(GetStdHandle(StdHandle.StdIn)); }
        }

        /// <summary>
        /// Gets a value that indicates whether output has been redirected from the standard output stream.
        /// </summary>
        internal static Boolean IsOutputRedirected
        {
            get { return FileType.Char != GetFileType(GetStdHandle(StdHandle.StdOut)); }
        }

        /// <summary>
        /// Gets the column position of the cursor within the buffer area.
        /// </summary>
        /// <param name="returnLeftIfNone">
        /// In the event that there is no console, the value passed here will be the return value
        /// </param>
        /// <returns>
        /// The current position, in columns, of the cursor
        /// </returns>
        internal static Int32 GetConsoleCursorLeft(Int32 returnLeftIfNone = 0)
        {
            if (!IsOutputRedirected) // if the output is not being redirected
                return Console.CursorLeft; // return the current cursor [left] position
            else
            { // try and get the Console Buffer details
                ConsoleScreenBufferInfo csbi;
                if (GetConsoleScreenBufferInfo(GetStdHandle(StdHandle.StdOut), out csbi)) // if the console buffer exists
                    return csbi.dwCursorPosition.X; // return the cursor [left] position
            }

            return returnLeftIfNone; // no console; return the desired position in this event
        }

        /// <summary>
        /// Gets the console screen buffer window height.
        /// </summary>
        /// <param name="windowHeight">
        /// A System.Int32 property that will receive the console screen buffer height
        /// </param>
        /// <returns>
        /// Returns a System.Boolean value of true if a console screen exists and the height retrieved; else false
        /// </returns>
        internal static Boolean GetConsoleWindowHeight(out Int32 windowHeight)
        {
            int discardWidth;
            return GetConsoleWindowSize(out windowHeight, out discardWidth);
        }

        /// <summary>
        /// Gets the console screen buffer window size.
        /// </summary>
        /// <param name="windowHeight">
        /// A System.Int32 property that will receive the console screen buffer height
        /// </param>
        /// <param name="windowWidth">
        /// A System.Int32 property that will receive the console screen buffer width
        /// </param>
        /// <returns>
        /// Returns a System.Boolean value of true if a console screen exists and the information retrieved; else false
        /// </returns>
        internal static Boolean GetConsoleWindowSize(out Int32 windowHeight, out Int32 windowWidth)
        {
            windowHeight = 0;
            windowWidth = 0;

            if (!IsOutputRedirected)
            { // if the output is not being redirected
                windowHeight = Console.WindowHeight; // out the current console window height
                windowWidth = Console.WindowWidth; // out the current console window width
                return true;
            }
            else
            { // try and get the Console Buffer details
                ConsoleScreenBufferInfo csbi;
                if (GetConsoleScreenBufferInfo(GetStdHandle(StdHandle.StdOut), out csbi))
                { // if the console buffer exists
                    windowHeight = csbi.dwSize.Y; // out the current console window height
                    windowWidth = csbi.dwSize.X; // out the current console window width
                    return true;
                }
            }

            return false; // no console
        }

        /// <summary>
        /// Gets the console screen buffer window height.
        /// </summary>
        /// <param name="windowWidth">
        /// A System.Int32 property that will receive the console screen buffer width
        /// </param>
        /// <returns>
        /// Returns a System.Boolean value of true if a console screen exists and the width retrieved; else false
        /// </returns>
        internal static Boolean GetConsoleWindowWidth(out Int32 windowWidth)
        {
            int discardHeight;
            return GetConsoleWindowSize(out discardHeight, out windowWidth);
        }

        /// <summary>
        /// Retrieves information about the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer
        /// </param>
        /// <param name="lpConsoleScreenBufferInfo">
        /// A pointer to a ConsoleScreenBufferInfo structure that receives the console screen buffer information
        /// </param>
        /// <returns>
        /// If the information retrieval succeeds, the return value is nonzero; else the return value is zero
        /// </returns>
        [DllImport("kernel32.dll")]
        private static extern Boolean GetConsoleScreenBufferInfo(
            IntPtr hConsoleOutput,
            out ConsoleScreenBufferInfo lpConsoleScreenBufferInfo);

        /// <summary>
        /// Retrieves the file type of the specified file.
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file
        /// </param>
        /// <returns>
        /// Returns one of the FileType enum values
        /// </returns>
        [DllImport("kernel32.dll")]
        private static extern FileType GetFileType(IntPtr hFile);

        /// <summary>
        /// Retrieves a handle to the specified standard device (standard input, standard output, or standard error).
        /// </summary>
        /// <param name="nStdHandle">
        /// The standard device
        /// </param>
        /// <returns>
        /// Returns a value that is a handle to the specified device, or a redirected handle
        /// </returns>
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(StdHandle nStdHandle);

        /// <summary>
        /// Defines the coordinates of the upper left and lower right corners of a rectangle.
        /// </summary>
        private struct SmallRect
        {
            /// <summary> The x-coordinate of the upper left corner of the rectangle. </summary>
            internal Int16 Left;
            /// <summary> The y-coordinate of the upper left corner of the rectangle. </summary>
            internal Int16 Top;
            /// <summary> The x-coordinate of the lower right corner of the rectangle. </summary>
            internal Int16 Right;
            /// <summary> The y-coordinate of the lower right corner of the rectangle. </summary>
            internal Int16 Bottom;
        }

        /// <summary>
        /// Defines the handle type of a standard device.
        /// </summary>
        private enum StdHandle
        {
            /// <summary> The standard input device. Initially, this is the console input buffer, CONIN$. </summary>
            StdIn = -10,
            /// <summary> The standard output device. Initially, this is the active console screen buffer, CONOUT$. </summary>
            StdOut = -11,
            /// <summary> The standard error device. Initially, this is the active console screen buffer, CONOUT$. </summary>
            StdErr = -12
        };

        /// <summary>
        /// Writes the specified string value to the standard output stream.
        /// </summary>
        /// <param name="value">
        /// The value to write
        /// </param>
        /// <param name="valueLength">
        /// The length of the last line written from value
        /// </param>
        /// 

        internal static void Write(String value, out Int32 valueLength)
        {
            string[] valueArray = value.Split(new char[] { '\r', '\n' }); 
            valueLength = valueArray[valueArray.Count() - 1].Length; 

            Console.Write(value); 

        }




        string[] datatype = {"عدد_ثنائى", "عدد_صحيح", "جملة", "جمله", "عدد_عشرى" , "عدد_عشري" };
        string[] separator = { "؛", "{", "}", "\r", "\n", "\r\n" };
        string[] comments = { "//", "/*", "*/" };
        string[] mathOperators = { "+", "-", "*", "/", "%" };
        string[] operators = { "+", "-", "*", "/", "%", "!", "&&", "||", ",", "++", "--" };
        string[] checkOperators = { "==", "!=", "<", ">", "<=", ">=" };
        public string type;

   
        public struct code
        {

            public string word;
            public string line;
        }
        public struct intvar
        {

            public string word;
            public int Addres;
        }

        public struct function
        {

            public string name;
            public code[] body;
            public intvar[] intVar;
            public floatvar[] floatVar;
            public stringvar[] stringVar;
            public boolvar[] boolVar;
            //  List<int> insawdadadtVar = new List<int>();

        }
        public struct floatvar
        {

            public string word;
            public double value;
        }
        public struct stringvar
        {

            public string word;
            public string value;
        }
        public struct boolvar
        {

            public string word;
            public bool value;
        }
        public struct arrays
        {

            public string name;
            public int linght;
        }

    


        //bt2sm el array of lines to arry of strings
        public static code[] linsArrayword(string[] lins)
        {

            
            List<code> zzz = new List<code>();
            List<code> zzz2 = new List<code>();
            char[] c = { ' ' };
            //     string temp = "";
            int z = 0;
            code linee;
            foreach (string x in lins)
            {
                //  temp = "  " + temp + x;
                z++;
                //  code linee;

                linee.word = x;
                linee.line = z.ToString();

                zzz.Add(linee);


            }

            foreach (code x in zzz)
            {

                string[] wordsz = x.word.Split(c, StringSplitOptions.RemoveEmptyEntries);

                foreach (string y in wordsz)
                {
                    linee.word = y;
                    linee.line = x.line;
                  
                    zzz2.Add(linee);
                }



            }

           code[] words = zzz2.ToArray();
            //  string[] words = temp.Split(c, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }


        //bt2sm el text L array of lines
        public static code[] WordsArray(string text)
        {

            string[] lines = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            code[] txttoarry = linsArrayword(lines);
            return txttoarry;
        }




        // Initialize el Grammar
        void startfun()
        {
            grammer.Add("عدد_صحيح");
            grammer.Add("جمله");
            grammer.Add("جملة");
            grammer.Add("عدد_عشري");
            grammer.Add("عدد_عشرى");
            grammer.Add("لو");
            grammer.Add("كرر");
            grammer.Add("فارغ");
            grammer.Add("اطبع");
            grammer.Add("أطبع");
            grammer.Add("ادخل");
            grammer.Add("أدخل");
            grammer.Add("عدد_ثنائى");
            grammer.Add("عدد_ثنائي");


            addToGrammar(datatype);
            addToGrammar(separator);
            addToGrammar(comments);
            addToGrammar(operators);
            addToGrammar(checkOperators);
            addToGrammar(grammer);
        }
        outputForm f1;
        public Form1()
        {
            InitializeComponent();

            startfun();
             f1 = new outputForm(this);

        }

        //trkeem elstoor bt5ly el rkm elstr nfs 7gm w lon el5t
        public int getWidth()
        {
            int w = 25;
            // get total lines of richTextBox1    
            int line = txtInput.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)txtInput.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)txtInput.Font.Size;
            }
            else
            {
                w = 50 + (int)txtInput.Font.Size;
            }

            return w;
        }
        int arkaaam = 21;
        //trkeem elstoor 
        public void AddLineNumbers()
        {
            // create & set Point pt to (0,0)    
            Point pt = new Point(0, 0);
            // get First Index & First Line from richTextBox1    
            int First_Index = txtInput.GetCharIndexFromPosition(pt);
            int First_Line = txtInput.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTextBox1    
            int Last_Index = txtInput.GetCharIndexFromPosition(pt);
            int Last_Line = txtInput.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox    
            LineNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            LineNumberTextBox.Text = "";
            LineNumberTextBox.Width = getWidth();
            // now add each line number to LineNumberTextBox upto last line    
            for (int i = First_Line; i <= Last_Line + arkaaam; i++)
            {
                LineNumberTextBox.Text += i + 1 + "\n";
            }
        }

        //void test()
        //{
        //    int y = 4, f = 0;
        //    for (int x = 0; y > 0; f=2)
        //    {
        //        x++;



        //    }
        //}

            public void sss()
        {
            //  Console.Clear();
          
                //     Console.Out.Close();
                ///   Console.Clear();
                //    FreeConsole();
                // Console.Clear();
                f1.clearout();
                f1.Hide();

                //   var handle = GetConsoleWindow();

                // Hide
                //  Console.Clear();
                //  ShowWindow(handle, SW_HIDE);
           
        }

        void addToGrammar(string newWord)
        { allGrammar.Add(newWord); }
        void addToGrammar(string[] newWord)
        { allGrammar.AddRange(newWord); }
        void addToGrammar(List<string> newWord)
        { allGrammar.AddRange(newWord); }

        void addToGlobalChak(List<string> newWord)
        { globalgrammerchak.AddRange(newWord); }

        //LL errors Ely tzhr
        void errorMassage(code e)
        {
            string temp = txtErorr.Text;
            txtErorr.Text = temp + "سطر رقم (" + e.line + ")   " + e.word + Environment.NewLine;
        }

        void errorMassage(string e)
        {
            string temp = txtErorr.Text;
            txtErorr.Text = temp + e + Environment.NewLine;
        }









        private void button2_Click(object sender, EventArgs e)
        {
           



        }










        string same;
       bool z;
        void ifRule(code[] arrCode, ref int index )
        {
            //  string[] arr = WordsArray(txtinput.Text);
            //    index = index + 1;
            // MessageBox.Show(index.ToString());
            ++index;
            if (arrCode.Length - 1 <= index)
            {
                code a;
                a.line = "الاخير";
                a.word = "لايوجد كود ";
                errorMassage(a);
                return;
            }

            if (arrCode[index].word != "(")
            {
                errorMassage(arrCode[index]);
              //  ++index;


            }
            ++index;
            if (arrCode.Length - 1 <= index)
            {
                code a;
                a.line = "الاخير";
                a.word = "لايوجد كود ";
                errorMassage(a);
                return;
            }
            if (funIntVariables.Contains(arrCode[index].word)||intVariables.Contains(arrCode[index].word) || floatVariables.Contains(arrCode[index].word) || stringVariables.Contains(arrCode[index].word)|| boolVariables.Contains(arrCode[index].word))
            {
                same = arrCode[index].word;

                if (intVariables.Contains(arrCode[index].word)||funIntVariables.Contains(arrCode[index].word))
                {
                    type = "integar";

                }
                if (floatVariables.Contains(arrCode[index].word))
                {
                    type = "float";

                }
                if (stringVariables.Contains(arrCode[index].word))
                {
                    type = "string";

                }
                if (boolVariables.Contains(arrCode[index].word))
                {
                    type = "bool";

                }

            }
            else
            {
                errorMassage(arrCode[index]);
               // ++index;

               

            }
            ++index;
            if (arrCode.Length - 1 <= index)
            {
                code a;
                a.line = "الاخير";
                a.word = "لايوجد كود ";
                errorMassage(a);
                return;
            }
            if (!checkOperators.Contains(arrCode[index].word))
            {
                errorMassage(arrCode[index]);
             //   ++index;
              //  return;

            }
            ++index;
            if (arrCode.Length - 1 <= index)
            {
                code a;
                a.line = "الاخير";
                a.word = "لايوجد كود ";
                errorMassage(a);
                return;
            }
            if (funIntVariables.Contains(arrCode[index].word)|| boolVariables.Contains(arrCode[index].word) || intVariables.Contains(arrCode[index].word) || floatVariables.Contains(arrCode[index].word) || stringVariables.Contains(arrCode[index].word))
            {
                if (intVariables.Contains(arrCode[index].word) || funIntVariables.Contains(arrCode[index].word))
                {
                    if(type== "integar")
                    {
                        
                    }
                    else
                    {
                        if (type != "integar")
                            errorMassage(arrCode[index]);
                    }
                    

                }
                if (boolVariables.Contains(arrCode[index].word))
                {
                    if (type == "bool")
                    {

                    }
                    else
                    {
                        if (type != "bool")
                            errorMassage(arrCode[index]);
                    }


                }
                if (floatVariables.Contains(arrCode[index].word))
                {
                    if (type == "float")
                    {

                    }
                    else
                    {
                        if (type != "float")
                            errorMassage(arrCode[index]);
                    }


                }
                if (stringVariables.Contains(arrCode[index].word))
                {
                    if (type == "string")
                    {

                    }
                    else
                    {
                        if (type != "string")
                            errorMassage(arrCode[index]);
                    }


                }
                if (arrCode[index].word == same)
                {
                    errorMassage(arrCode[index]);
                    //++index;
                   // return;
                }
            }
            else
            {


                
                if (type == "float")
                {

                    try
                    {
                        double anInteger;
                        anInteger = Convert.ToDouble(arrCode[index].word);
                        
                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                       // ++index;
                       // return;
                    }


                }
           

                if (type == "integar")
                {

                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                       // ++index;
                       // return;
                    }


                }
                if (type == "bool")
                {
                  

                    if (arrCode[index].word == "صح")
                    {
                        z = true;
                    }
                    else
                    {
                        if (arrCode[index].word == "خطأ")
                        {
                            z = false;
                        }
                        else
                        {
                            if (arrCode[index].word == "خطا")
                            {
                                z = false;
                            }else
                            {
                                errorMassage(arrCode[index]);
                            }
                        }
                    }
                    
                    //try
                    //{
                    //    bool anInteger;
                    //    anInteger = Convert.ToBoolean(arrCode[index].word);

                    //}
                    //catch
                    //{
                    //    errorMassage(arrCode[index]);
                    //    // ++index;
                    //    // return;
                    //}


                }

                if (type == "string")
                {
                    int aa = index;
                    if (arrCode[index].word == "\"")
                    {
                        string pp="";
                        index++;
                        if (arrCode.Length - 1 <= index)
                        {
                            code a;
                            a.line = "الاخير";
                            a.word = "لايوجد كود ";
                            errorMassage(a);
                            return;
                        }
                        while (arrCode[index].word!="\"")
                        {
                         
                            if (arrCode[index].word == "\"")
                            {
                                // index++;
                                //  break;
                            }
                            else
                            {

                                pp = pp + arrCode[index].word;
                                index++;
                                if (index + 1  >= arrCode.Length)
                                {
                                    errorMassage(arrCode[aa]);
                                   
                                   
                                    break;
                                    //return;

                                }
                            }

                            
                        }
                      //  index++;
                    }
                    else
                    {
                        errorMassage(arrCode[index]);
                       // ++index;
                       // return;
                    }



                }
              





            }

            ++index;
            if (arrCode.Length - 1 <= index)
            {
                code a;
                a.line = "الاخير";
                a.word = "لايوجد كود ";
                errorMassage(a);
                return;
            }
            if (arrCode[index].word != ")")
            {
                errorMassage(arrCode[index]);
              //  ++index;

            }

            ++index;
            if (arrCode.Length - 1 <= index)
            {
                code a;
                a.line = "الاخير";
                a.word = "لايوجد كود ";
                errorMassage(a);
                return;
            }

            if (arrCode[index].word == "{")
            {
                List<code> iflist = new List<code>();
                code temp;
                int count = 1;
                index++;
                for (int i = index; i < arrCode.Length; i++)
                {
                    if (i == arrCode.Length)
                    {
                        errorMassage(arrCode[index]);
                    }
                    else
                    {
                        if (arrCode[i].word == "{")
                        {
                            count++;

                            temp.word = arrCode[i].word;
                            temp.line = arrCode[i].line;
                            iflist.Add(temp);
                        }
                        else
                        {
                            if (arrCode[i].word == "}")
                            {
                                count--;
                                if (count == 0)
                                {
                                    index = i - 1;
                                    i = arrCode.Length;
                                    break;
                                }
                                else
                                {
                                    //count--;
                                    temp.word = arrCode[i].word;
                                    temp.line = arrCode[i].line;
                                    iflist.Add(temp);
                                }
                            }
                            else
                            {
                                temp.word = arrCode[i].word;
                                temp.line = arrCode[i].line;
                                iflist.Add(temp);
                            }
                        }

                    }
                }
                if (count == 0)
                {
                    code[] forCode = iflist.ToArray();

                    //hnd5l elcode ely b3d el akwaas  l7d 2flt el kos
                    syntax_Errors_fun(forCode);
                }
                else
                {
                    code aa;
                    aa.word = "قفلة القوس ل جملة لو ";
                    aa.line = "تحقق من الاقواس";
                    errorMassage(aa);

                }
            }
            else
            {
                if (arrCode[index].word != "{")
                {
                    errorMassage(arrCode[index]);
                }





            }


            index++;
            if (arrCode.Length <= index)
            {
                code aa;
                aa.word = "قفلة القوس  ";
                aa.line = "الاخير";
                errorMassage(aa);
                return;

            }
            if (arrCode[index].word == "}")
            { }
            else
            {
                if (arrCode[index].word != "}")
                {
                    errorMassage(arrCode[index]);
                    ++index;
                }
            }
            index++;
         
            if (arrCode.Length > index)
            {
                if (arrCode[index].word == "غيرذلك")
                {
                    index++;

                    if (arrCode.Length - 1 <= index)
                    {
                        code a;
                        a.line = "الاخير";
                        a.word = "لايوجد كود ";
                        errorMassage(a);
                        return;
                    }

                    if (arrCode[index].word == "{")
                    {
                        List<code> iflist = new List<code>();
                        code temp;
                        int count = 1;
                        index++;
                        for (int i = index; i < arrCode.Length; i++)
                        {
                            if (i == arrCode.Length)
                            {
                                errorMassage(arrCode[index]);
                            }
                            else
                            {
                                if (arrCode[i].word == "{")
                                {
                                    count++;

                                    temp.word = arrCode[i].word;
                                    temp.line = arrCode[i].line;
                                    iflist.Add(temp);
                                }
                                else
                                {
                                    if (arrCode[i].word == "}")
                                    {
                                        count--;
                                        if (count == 0)
                                        {
                                            index = i - 1;
                                            i = arrCode.Length;
                                            break;
                                        }
                                        else
                                        {
                                            //count--;
                                            temp.word = arrCode[i].word;
                                            temp.line = arrCode[i].line;
                                            iflist.Add(temp);
                                        }
                                    }
                                    else
                                    {
                                        temp.word = arrCode[i].word;
                                        temp.line = arrCode[i].line;
                                        iflist.Add(temp);
                                    }
                                }

                            }
                        }
                        if (count == 0)
                        {
                            code[] forCode = iflist.ToArray();

                            //hnd5l elcode ely b3d el akwaas  l7d 2flt el kos
                            syntax_Errors_fun(forCode);
                        }
                        else
                        {
                            code aa;
                            aa.word = "قفلة القوس ل جملة غير ذلك ";
                            aa.line = "تحقق من الاقواس";
                            errorMassage(aa);

                        }
                    }
                    else
                    {
                        if (arrCode[index].word != "{")
                        {
                            errorMassage(arrCode[index]);
                        }





                    }






                }
                else
                {
                    index--;
                    return;
                }




            }
            else
            {
                index--;
                return;
            }

            //     ++index;
            //   return;

            //  MessageBox.Show(index.ToString());

        }



        string z1, z2, z3;
        int elsegate = 3;

        void ifRuleRun(code[] arrCode, ref int index, ref function init)
        {
            //  string[] arr = WordsArray(txtinput.Text);
            //    index = index + 1;
            // MessageBox.Show(index.ToString());
            elsegate = 3;
            ++index;
            if (arrCode.Length - 1 <= index)
            {
                code a;
                a.line = "الاخير";
                a.word = "لايوجد كود ";
                //  errorMassage(a);
                //  return;
            }

            if (arrCode[index].word != "(")
            {
                //   errorMassage(arrCode[index]);
                //  ++index;


            }
            ++index;
            if (arrCode.Length - 1 <= index)
            {
                code a;
                a.line = "الاخير";
                a.word = "لايوجد كود ";
                errorMassage(a);
                return;
            }
            if (intVariables.Contains(arrCode[index].word) || floatVariables.Contains(arrCode[index].word) || stringVariables.Contains(arrCode[index].word) || boolVariables.Contains(arrCode[index].word))
            {
                same = arrCode[index].word;

                if (intVariables.Contains(arrCode[index].word))
                {
                    type = "integar";
                    foreach (intvar v in intVariablesval)
                    {
                        if (v.word == arrCode[index].word)
                        {
                            z1 = v.Addres.ToString();
                        }
                    }



                }
                if (floatVariables.Contains(arrCode[index].word))
                {
                    type = "float";

                }
                if (stringVariables.Contains(arrCode[index].word))
                {
                    type = "string";

                }
                if (boolVariables.Contains(arrCode[index].word))
                {
                    type = "bool";

                }

            }
            else
            {
                //  errorMassage(arrCode[index]);
                // ++index;
                try
                {
                    int anInteger;
                    anInteger = Convert.ToInt32(arrCode[index].word);
                    z1 = anInteger.ToString();
                    type = "integar";
                }
                catch
                {
                    for (int i = 0; i < init.intVar.Length; i++)
                    {
                        if (init.intVar[i].word == arrCode[index].word)
                        {
                            z1 = init.intVar[i].Addres.ToString();
                            type = "integar";
                        }
                    }
                }



            }
            ++index;
            if (arrCode.Length - 1 <= index)
            {
                code a;
                a.line = "الاخير";
                a.word = "لايوجد كود ";
                //  errorMassage(a);
                //  return;
            }
            if (checkOperators.Contains(arrCode[index].word))
            {

                z2 = arrCode[index].word;
                //errorMassage(arrCode[index]);
                //   ++index;
                //  return;

            }
            ++index;
            if (arrCode.Length - 1 <= index)
            {
                code a;
                a.line = "الاخير";
                a.word = "لايوجد كود ";
                // errorMassage(a);
                //  return;
            }
            if (boolVariables.Contains(arrCode[index].word) || intVariables.Contains(arrCode[index].word) || floatVariables.Contains(arrCode[index].word) || stringVariables.Contains(arrCode[index].word))
            {
                if (intVariables.Contains(arrCode[index].word))
                {
                    if (type == "integar")
                    {
                        foreach (intvar v in intVariablesval)
                        {
                            if (v.word == arrCode[index].word)
                            {
                                z3 = v.Addres.ToString();
                                //  MessageBox.Show(v.Addres.ToString() + "   " + v.word);
                            }
                        }
                    }
                    else
                    {
                        if (type != "integar")
                        { }
                        //  errorMassage(arrCode[index]);
                    }


                }
                if (boolVariables.Contains(arrCode[index].word))
                {
                    if (type == "bool")
                    {

                    }
                    else
                    {
                        if (type != "bool")
                            errorMassage(arrCode[index]);
                    }


                }
                if (floatVariables.Contains(arrCode[index].word))
                {
                    if (type == "float")
                    {

                    }
                    else
                    {
                        if (type != "float")
                            errorMassage(arrCode[index]);
                    }


                }
                if (stringVariables.Contains(arrCode[index].word))
                {
                    if (type == "string")
                    {

                    }
                    else
                    {
                        if (type != "string")
                            errorMassage(arrCode[index]);
                    }


                }
                if (arrCode[index].word == same)
                {
                    errorMassage(arrCode[index]);
                    //++index;
                    // return;
                }
            }
            else
            {


                switch (type)
                {
                    case "float":


                        try
                        {
                            double anInteger;
                            anInteger = Convert.ToDouble(arrCode[index].word);

                        }
                        catch
                        {
                            errorMassage(arrCode[index]);
                            // ++index;
                            // return;
                        }
                        break;



                    case "integar":






                        try
                        {
                            int anInteger;
                            anInteger = Convert.ToInt32(arrCode[index].word);

                            z3 = arrCode[index].word;

                        }
                        catch
                        {
                            for (int i = 0; i < init.intVar.Length; i++)
                            {
                                if (init.intVar[i].word == arrCode[index].word)
                                {
                                    z3 = init.intVar[i].Addres.ToString();
                                    // type = "integar";
                                }
                            }
                            foreach (intvar v in intVariablesval)
                            {
                                if (v.word == arrCode[index].word)
                                {
                                    z3 = v.Addres.ToString();
                                    //  MessageBox.Show(v.Addres.ToString() + "   " + v.word);
                                }
                            }

                        }



                        break;



                    case "bool":



                        if (arrCode[index].word == "صح")
                        {
                            z = true;
                        }
                        else
                        {
                            if (arrCode[index].word == "خطأ")
                            {
                                z = false;
                            }
                            else
                            {
                                if (arrCode[index].word == "خطا")
                                {
                                    z = false;
                                }
                                else
                                {
                                    errorMassage(arrCode[index]);
                                }
                            }
                        }

                        //try
                        //{
                        //    bool anInteger;
                        //    anInteger = Convert.ToBoolean(arrCode[index].word);

                        //}
                        //catch
                        //{
                        //    errorMassage(arrCode[index]);
                        //    // ++index;
                        //    // return;
                        //}



                        break;

                    case "string":

                        int aa = index;
                        if (arrCode[index].word == "\"")
                        {
                            string pp = "";
                            index++;
                            if (arrCode.Length - 1 <= index)
                            {
                                code a;
                                a.line = "الاخير";
                                a.word = "لايوجد كود ";
                                errorMassage(a);
                                return;
                            }
                            while (arrCode[index].word != "\"")
                            {

                                if (arrCode[index].word == "\"")
                                {
                                    // index++;
                                    //  break;
                                }
                                else
                                {

                                    pp = pp + arrCode[index].word;
                                    index++;
                                    if (index + 1 >= arrCode.Length)
                                    {
                                        errorMassage(arrCode[aa]);


                                        break;
                                        //return;

                                    }
                                }


                            }
                            //  index++;
                        }
                        else
                        {
                            errorMassage(arrCode[index]);
                            // ++index;
                            // return;
                        }




                        break;

                    default:
                        MessageBox.Show("type fl for m4 m3roof");
                        break;





                }




                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (arrCode[index].word != ")")
                {
                    errorMassage(arrCode[index]);
                    //  ++index;

                }

                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }

                if (arrCode[index].word == "{")
                {
                    List<code> iflist = new List<code>();
                    code temp;
                    int count = 1;
                    index++;
                    for (int i = index; i < arrCode.Length; i++)
                    {
                        if (i == arrCode.Length)
                        {
                            errorMassage(arrCode[index]);
                        }
                        else
                        {
                            if (arrCode[i].word == "{")
                            {
                                count++;

                                temp.word = arrCode[i].word;
                                temp.line = arrCode[i].line;
                                iflist.Add(temp);
                            }
                            else
                            {
                                if (arrCode[i].word == "}")
                                {
                                    count--;
                                    if (count == 0)
                                    {
                                        index = i - 1;
                                        i = arrCode.Length;
                                        break;
                                    }
                                    else
                                    {
                                        //count--;
                                        temp.word = arrCode[i].word;
                                        temp.line = arrCode[i].line;
                                        iflist.Add(temp);
                                    }
                                }
                                else
                                {
                                    temp.word = arrCode[i].word;
                                    temp.line = arrCode[i].line;
                                    iflist.Add(temp);
                                }
                            }

                        }
                    }
                    if (count == 0)
                    {
                        code[] forCode = iflist.ToArray();

                        //hnd5l elcode ely b3d el akwaas  l7d 2flt el kos
                        if (type == "integar")
                        {
                            int aa1, aa2;


                            aa1 = Convert.ToInt32(z1);
                            aa2 = Convert.ToInt32(z3);

                     //       MessageBox.Show(" z1 = " + aa1.ToString()+"  z2 = "+ z2 +"  z3 = " + aa2.ToString());

                            switch (z2)
                            {
                                case ">":
                                    if (aa1 > aa2)
                                    {
                                        //elsegate = 0;
                                        syntax_ErrorsRun(forCode, ref init);
                                        elsegate = 0;


                                    }
                                    break;
                                case "<":
                                    if (aa1 < aa2)
                                    {

                                        //elsegate = 0;
                                        syntax_ErrorsRun(forCode, ref init);
                                        elsegate = 0;

                                    }
                                    break;
                                case ">=":
                                    if (aa1 >= aa2)
                                    {
                                       // elsegate = 0;
                                        syntax_ErrorsRun(forCode, ref init);
                                        elsegate = 0;

                                    }
                                    break;
                          
                                case "<=":
                                    if (aa1 <= aa2)
                                    {
                                      //  elsegate = 0;
                                        syntax_ErrorsRun(forCode, ref init);
                                        elsegate = 0;


                                    }
                                    break;
                              
                                case "==":
                                    if (aa1 == aa2)
                                    {
                                         //elsegate = 0;
                                        syntax_ErrorsRun(forCode, ref init);
                                        elsegate = 0;

                                    }
                                    break;

                                default:
                                    MessageBox.Show("eh DA OOOOOOOOOOOO eh ely d5lk hena ( for run switch z2 m3rfhaa4 )");
                                    break;


                            }









                        }

                    }
                    else
                    {
                        code aa;
                        aa.word = "قفلة القوس ل جملة لو ";
                        aa.line = "تحقق من الاقواس";
                          errorMassage(aa);

                    }
                }
                else
                {
                    if (arrCode[index].word != "{")
                    {
                        errorMassage(arrCode[index]);
                    }





                }


                index++;
                if (arrCode.Length <= index)
                {
                    code aa;
                    aa.word = "قفلة القوس  ";
                    aa.line = "الاخير";
                    errorMassage(aa);
                    return;

                }
                if (arrCode[index].word == "}")
                { }
                else
                {
                    if (arrCode[index].word != "}")
                    {
                        errorMassage(arrCode[index]);
                        ++index;
                    }
                }
                index++;

                if (arrCode.Length > index)
                {
                    if (arrCode[index].word == "غيرذلك")
                    {
                        index++;

                        if (arrCode.Length - 1 <= index)
                        {
                            code a;
                            a.line = "الاخير";
                            a.word = "لايوجد كود ";
                            errorMassage(a);
                            return;
                        }

                        if (arrCode[index].word == "{")
                        {
                            List<code> iflist = new List<code>();
                            code temp;
                            int count = 1;
                            index++;
                            for (int i = index; i < arrCode.Length; i++)
                            {
                                if (i == arrCode.Length)
                                {
                                    errorMassage(arrCode[index]);
                                }
                                else
                                {
                                    if (arrCode[i].word == "{")
                                    {
                                        count++;

                                        temp.word = arrCode[i].word;
                                        temp.line = arrCode[i].line;
                                        iflist.Add(temp);
                                    }
                                    else
                                    {
                                        if (arrCode[i].word == "}")
                                        {
                                            count--;
                                            if (count == 0)
                                            {
                                                index = i - 1;
                                                i = arrCode.Length;
                                                break;
                                            }
                                            else
                                            {
                                                //count--;
                                                temp.word = arrCode[i].word;
                                                temp.line = arrCode[i].line;
                                                iflist.Add(temp);
                                            }
                                        }
                                        else
                                        {
                                            temp.word = arrCode[i].word;
                                            temp.line = arrCode[i].line;
                                            iflist.Add(temp);
                                        }
                                    }

                                }
                            }
                            if (count == 0)
                            {
                                code[] forCode = iflist.ToArray();
                    //            MessageBox.Show("satr 1850");
                                //hnd5l elcode ely b3d el akwaas  l7d 2flt el kos
                                if (elsegate == 0)
                                { //MessageBox.Show(" elsgat == 0 ");

                                }
                                else
                                {
                                    if (elsegate != 0)
                                    {
                                        syntax_ErrorsRun(forCode, ref init);

                                        elsegate = 1;
                                    }
                                    else
                                    {
                                        MessageBox.Show("tmam md5l4 else");
                                    }
                                }
                            }
                            else
                            {
                                code aa;
                                aa.word = "قفلة القوس ل جملة غير ذلك ";
                                aa.line = "تحقق من الاقواس";
                                errorMassage(aa);

                            }
                        }
                        else
                        {
                            if (arrCode[index].word != "{")
                            {
                                errorMassage(arrCode[index]);
                            }





                        }






                    }
                    else
                    {
                        index--;
                        return;
                    }




                }
                else
                {
                    index--;
                    return;
                }

                //     ++index;
                //   return;

                //  MessageBox.Show(index.ToString());

            }
            elsegate = 3;

        }



        string counterinfor;
        void forRule(code[] arrCode, ref int index )
        {
            // string[] arr = WordsArray(txtinput.Text);
           
            ++index;
            try
            {
                if (arrCode[index].word != "(")
                {
                    errorMassage(arrCode[index]);
                   // return;
                }
            }
            catch
            {
                code a;
                a.line = "الاخير";
                a.word = "لايوجد كود ";

                errorMassage(a);
                return;
            }
            ++index;

            if (arrCode.Length - 1 <= index)
            {
                code a;
                a.line = "الاخير";
                a.word = "لايوجد كود ";
                errorMassage(a);
                return;
            }


            if (arrCode[index].word == "عدد_صحيح")
            {

                index++;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (allGrammar.Contains(arrCode[index].word))
                {
                    errorMassage(arrCode[index]);
                   // return;
                }
                else
                {
                    counterinfor = arrCode[index].word;
                    intVariables.Add(counterinfor);
                    allGrammar.Add(counterinfor);
                    //if (!intVariables.Contains(arrCode[index].word))
                    //{

                    //}
                }
                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (arrCode[index].word != "=")
                {
                    errorMassage(arrCode[index]);
                   // return;
                }
                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (intVariables.Contains(arrCode[index].word))
                {
                    //if (arrCode[index].word == same)
                    //{
                    //    errorMassage(arrCode[index]);
                    //    ++index;
                    //    return;
                    //}
                    if(counterinfor==arrCode[index].word)
                    {
                        errorMassage(arrCode[index]);
                    }

                }
                else
                {


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                        //++index;
                      //  return;
                    }



                }
                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (arrCode[index].word == semi.ToString())
                {

                }
                else
                {
                    if (arrCode[index].word != ":")
                    {
                        errorMassage(arrCode[index]);
                      //  ++index;
                      //  return;
                    }
                }
                index++;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (intVariables.Contains(arrCode[index].word))
                {

                }
                else
                {
                    if (!intVariables.Contains(arrCode[index].word))
                    {
                        errorMassage(arrCode[index]);
                       // ++index;
                       // return;
                    }
                }
                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (!checkOperators.Contains(arrCode[index].word))
                {
                    errorMassage(arrCode[index]);
                   // ++index;
                   // return;
                }
                else
                {
                    if (checkOperators.Contains(arrCode[index].word))
                    {

                    }
                }

                index++;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }

                if (intVariables.Contains(arrCode[index].word))
                {
                    //if (arrCode[index].word == same)
                    //{
                    //    errorMassage(arrCode[index]);
                    //    ++index;
                    //    return;
                    //}
                    if(counterinfor==arrCode[index].word)
                    {
                        errorMassage(arrCode[index]);
                    }
                }
                else
                {


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                      //  ++index;
                      //  return;
                    }



                }
                index++;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }

                if (arrCode[index].word == semi.ToString())
                {

                }
                else
                {
                    if (arrCode[index].word !=semi.ToString())
                    {
                        errorMassage(arrCode[index]);
                        //++index;
                        //return;
                    }
                }

                index++;

                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }













                if (!intVariables.Contains(arrCode[index].word))
                {
                    errorMassage(arrCode[index]);
                   // return;
                }
                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }

                if (arrCode[index].word == "++" || arrCode[index].word == "--")
                {

                }
                else
                {
                    if (arrCode[index].word != "++" && arrCode[index].word != "--")
                    {
                        errorMassage(arrCode[index]);
                       // ++index;
                      //  return;
                    }
                }





                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }

                if (arrCode[index].word != ")")
                {
                    errorMassage(arrCode[index]);
                   // ++index;

                }

                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (arrCode[index].word == "{")
                {
                    List<code> forlist = new List<code>();
                    code temp;
                    int count = 1;
                    index++;
                    for (int i = index; i < arrCode.Length; i++)
                    {
                        if (i == arrCode.Length)
                        {
                            errorMassage(arrCode[index]);
                        }
                        else
                        {
                            if (arrCode[i].word == "{")
                            {
                                count++;

                                temp.word = arrCode[i].word;
                                temp.line = arrCode[i].line;
                                forlist.Add(temp);
                            }
                            else
                            {
                                if (arrCode[i].word == "}")
                                {
                                    count--;
                                    if (count == 0)
                                    {
                                        index = i - 1;
                                        i = arrCode.Length;
                                        break;
                                    }
                                    else
                                    {
                                        //count--;
                                        temp.word = arrCode[i].word;
                                        temp.line = arrCode[i].line;
                                        forlist.Add(temp);
                                    }
                                }
                                else
                                {
                                    temp.word = arrCode[i].word;
                                    temp.line = arrCode[i].line;
                                    forlist.Add(temp);
                                }
                            }

                        }
                    }
                    if (count == 0)
                    {
                        code[] forCode = forlist.ToArray();

                        //hnd5l elcode ely b3d el akwaas  l7d 2flt el kos
                        syntax_Errors_for(forCode);

                        intVariables.Remove(counterinfor);
                        allGrammar.Remove(counterinfor);
                    }
                    else
                    {
                        code aa;
                        aa.word = "قفلة القوس ل جملة كرر ";
                        aa.line = "تحقق من الاقواس";
                        errorMassage(aa);

                    }
                }
                else
                {
                    if (arrCode[index].word != "{")
                    {
                        errorMassage(arrCode[index]);
                    }
                }


            }




            else
            {


                if (intVariables.Contains(arrCode[index].word))
                {

                }
                else
                {
                    if (!intVariables.Contains(arrCode[index].word))
                    {
                        errorMassage(arrCode[index]);
                      //  return;
                    }
                }
                ++index;

                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }

                if (arrCode[index].word != "=")
                {
                    errorMassage(arrCode[index]);
                   // return;
                }
                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }

                if (intVariables.Contains(arrCode[index].word))
                {
                    //if (arrCode[index].word == same)
                    //{
                    //    errorMassage(arrCode[index]);
                    //    ++index;
                    //    return;
                    //}
                    if (counterinfor == arrCode[index].word)
                    {
                        errorMassage(arrCode[index]);
                    }
                }
                else
                {


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                      //  ++index;
                      //  return;
                    }



                }
                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (arrCode[index].word == semi.ToString())
                {

                }
                else
                {
                    if (arrCode[index].word != semi.ToString())
                    {
                        errorMassage(arrCode[index]);
                      //  ++index;
                      //  return;
                    }
                }
                index++;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (intVariables.Contains(arrCode[index].word))
                {

                }
                else
                {
                    if (!intVariables.Contains(arrCode[index].word))
                    {
                        errorMassage(arrCode[index]);
                      //  ++index;
                      //  return;
                    }
                }
                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (!checkOperators.Contains(arrCode[index].word))
                {
                    errorMassage(arrCode[index]);
                  //  ++index;
                  //  return;
                }
                else
                {
                    if (checkOperators.Contains(arrCode[index].word))
                    {

                    }
                }

                index++;

                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (intVariables.Contains(arrCode[index].word))
                {
                    //if (arrCode[index].word == same)
                    //{
                    //    errorMassage(arrCode[index]);
                    //    ++index;
                    //    return;
                    //}
                    if(counterinfor==arrCode[index].word)
                    {
                        errorMassage(arrCode[index]);
                    }
                }
                else
                {


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                       // ++index;
                       // return;
                    }



                }
                index++;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (arrCode[index].word == semi.ToString())
                {

                }
                else
                {
                    if (arrCode[index].word != semi.ToString())
                    {
                        errorMassage(arrCode[index]);
                      //  ++index;
                      //  return;
                    }
                }

                index++;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (!intVariables.Contains(arrCode[index].word))
                {
                    errorMassage(arrCode[index]);
                   // return;
                }
                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }

                if (arrCode[index].word == "++" || arrCode[index].word == "--")
                {

                }
                else
                {
                    if (arrCode[index].word != "++" && arrCode[index].word != "--")
                    {
                        errorMassage(arrCode[index]);
                      //  ++index;
                      //  return;
                    }
                }





                ++index;

                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (arrCode[index].word != ")")
                {
                    errorMassage(arrCode[index]);
                  //  ++index;

                }

                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (arrCode[index].word == "{")
                {
                    List<code> forlist = new List<code>();
                    code temp;
                    int count = 1;
                    index++;
                    for (int i = index; i < arrCode.Length; i++)
                    {
                        if (i == arrCode.Length)
                        {
                            errorMassage(arrCode[index]);
                        }
                        else
                        {
                            if (arrCode[i].word == "{")
                            {
                                count++;

                                temp.word = arrCode[i].word;
                                temp.line = arrCode[i].line;
                                forlist.Add(temp);
                            }
                            else
                            {
                                if (arrCode[i].word == "}")
                                {
                                    count--;
                                    if (count == 0)
                                    {
                                        index = i - 1;
                                        i = arrCode.Length;
                                        break;
                                    }
                                    else
                                    {
                                        //count--;
                                        temp.word = arrCode[i].word;
                                        temp.line = arrCode[i].line;
                                        forlist.Add(temp);
                                    }
                                }
                                else
                                {
                                    temp.word = arrCode[i].word;
                                    temp.line = arrCode[i].line;
                                    forlist.Add(temp);
                                }
                            }

                        }
                    }
                    if (count == 0)
                    {
                        code[] forCode = forlist.ToArray();

                        //hnd5l elcode ely b3d el akwaas  l7d 2flt el kos
                        syntax_Errors_for(forCode);

                        intVariables.Remove(counterinfor);
                    }
                    else
                    {
                        code aa;
                        aa.word = "قفلة القوس ل جملة كرر ";
                        aa.line = "تحقق من الاقواس";
                        errorMassage(aa);

                    }
                }
                else
                {
                    if (arrCode[index].word != "{")
                    {
                        errorMassage(arrCode[index]);
                    }
                }


            }


            index++;
            //if (arrCode.Length - 1 <= index)
            //{
            //    code a;
            //    a.line = "الاخير";
            //    a.word = "القوس ل جملة كرر ";
            //    errorMassage(a);
            //    return;
            //}
            if (arrCode[index].word == "}")
            { }
            else
            {
                if (arrCode[index].word != "}")
                {
                    errorMassage(arrCode[index]);
                    ++index;

                }
            }
            //    index++;



            return;
        }

        //int qq1, qq2, qq3;
        //string opra, counter;
        void forRuleRun(code[] arrCode, ref int index , ref function init)
        {
            // string[] arr = WordsArray(txtinput.Text);
            int qq1=0, qq2=0, qq3=0;
            string opra="", counter="";
            ++index;
            //try
            //{
            //    if (arrCode[index].word != "(")
            //    {
            //        errorMassage(arrCode[index]);
            //        // return;
            //    }
            //}
            //catch
            //{
            //    code a;
            //    a.line = "الاخير";
            //    a.word = "لايوجد كود ";

            //    errorMassage(a);
            //    return;
            //}
            ++index;

            //if (arrCode.Length - 1 <= index)
            //{
            //    code a;
            //    a.line = "الاخير";
            //    a.word = "لايوجد كود ";
            //    errorMassage(a);
            //    return;
            //}


            if (arrCode[index].word == "عدد_صحيح")
            {

                index++;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (allGrammar.Contains(arrCode[index].word))
                {
                    errorMassage(arrCode[index]);
                    // return;
                }
                else
                {
                    counterinfor = arrCode[index].word;
                    intVariables.Add(counterinfor);
                    allGrammar.Add(counterinfor);
                    //if (!intVariables.Contains(arrCode[index].word))
                    //{

                    //}
                }
                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (arrCode[index].word != "=")
                {
                    errorMassage(arrCode[index]);
                    // return;
                }
                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (intVariables.Contains(arrCode[index].word))
                {
                    //if (arrCode[index].word == same)
                    //{
                    //    errorMassage(arrCode[index]);
                    //    ++index;
                    //    return;
                    //}
                    if (counterinfor == arrCode[index].word)
                    {
                        errorMassage(arrCode[index]);
                    }

                }
                else
                {


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);
                        intvar z;
                        z.Addres = anInteger;
                        z.word = counterinfor;
                        intVariablesval.Add(z);
                        qq1 = anInteger;
                    }
                    catch
                    {
                    //    errorMassage(arrCode[index]);
                        //++index;
                        //  return;
                    }



                }
                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (arrCode[index].word == semi.ToString())
                {

                }
                else
                {
                    if (arrCode[index].word != ":")
                    {
                        errorMassage(arrCode[index]);
                        //  ++index;
                        //  return;
                    }
                }
                index++;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (intVariables.Contains(arrCode[index].word))
                {

                }
                else
                {
                    if (!intVariables.Contains(arrCode[index].word))
                    {
                        errorMassage(arrCode[index]);
                        // ++index;
                        // return;
                    }
                }
                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (!checkOperators.Contains(arrCode[index].word))
                {
                    errorMassage(arrCode[index]);
                    // ++index;
                    // return;
                }
                else
                {
                    if (checkOperators.Contains(arrCode[index].word))
                    {
                        opra = arrCode[index].word;
                    }
                }

                index++;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }

                if (intVariables.Contains(arrCode[index].word))
                {
                    //if (arrCode[index].word == same)
                    //{
                    //    errorMassage(arrCode[index]);
                    //    ++index;
                    //    return;
                    //}
                    if (counterinfor == arrCode[index].word)
                    {
                        errorMassage(arrCode[index]);
                    }
                }
                else
                {


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);
                        qq2 = anInteger;

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                        //  ++index;
                        //  return;
                    }



                }
                index++;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }

                if (arrCode[index].word == semi.ToString())
                {

                }
                else
                {
                    if (arrCode[index].word != semi.ToString())
                    {
                        errorMassage(arrCode[index]);
                        //++index;
                        //return;
                    }
                }

                index++;

                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }













                if (!intVariables.Contains(arrCode[index].word))
                {
                    errorMassage(arrCode[index]);
                    // return;
                }
                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }

                if (arrCode[index].word == "++" || arrCode[index].word == "--")
                {
                    if(arrCode[index].word == "++")
                    {
                        qq3 = 1;
                    }
                    else
                    {
                        if (arrCode[index].word == "--")
                        {
                            qq3 = -1;
                        }
                    }
                }
                else
                {
                    if (arrCode[index].word != "++" && arrCode[index].word != "--")
                    {
                        errorMassage(arrCode[index]);
                        // ++index;
                        //  return;
                    }
                }





                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }

                if (arrCode[index].word != ")")
                {
                    errorMassage(arrCode[index]);
                    // ++index;

                }

                ++index;
                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if (arrCode[index].word == "{")
                {
                    List<code> forlist = new List<code>();
                    code temp;
                    int count = 1;
                    index++;
                    for (int i = index; i < arrCode.Length; i++)
                    {
                        if (i == arrCode.Length)
                        {
                            errorMassage(arrCode[index]);
                        }
                        else
                        {
                            if (arrCode[i].word == "{")
                            {
                                count++;

                                temp.word = arrCode[i].word;
                                temp.line = arrCode[i].line;
                                forlist.Add(temp);
                            }
                            else
                            {
                                if (arrCode[i].word == "}")
                                {
                                    count--;
                                    if (count == 0)
                                    {
                                        index = i - 1;
                                        i = arrCode.Length;
                                        break;
                                    }
                                    else
                                    {
                                        //count--;
                                        temp.word = arrCode[i].word;
                                        temp.line = arrCode[i].line;
                                        forlist.Add(temp);
                                    }
                                }
                                else
                                {
                                    temp.word = arrCode[i].word;
                                    temp.line = arrCode[i].line;
                                    forlist.Add(temp);
                                }
                            }

                        }
                    }
                    if (count == 0)
                    {
                        code[] forCode = forlist.ToArray();

                        //hnd5l elcode ely b3d el akwaas  l7d 2flt el kos
                        if (opra == "==")
                        {
                            if (qq3 == 1)
                            {
                                MessageBox.Show("sa");
                                for (int x = qq1; x == qq2; x++) 
                                    syntax_ErrorsRun(forCode,ref init);
                            }
                        }

                        intVariables.Remove(counterinfor);
                        allGrammar.Remove(counterinfor);
                    }
                    else
                    {
                        code aa;
                        aa.word = "قفلة القوس ل جملة كرر ";
                        aa.line = "تحقق من الاقواس";
                        errorMassage(aa);

                    }
                }
                else
                {
                    if (arrCode[index].word != "{")
                    {
                        errorMassage(arrCode[index]);
                    }
                }


            }




            else
            {


                counter = arrCode[index].word;
                if (intVariables.Contains(arrCode[index].word) ||funIntVariables.Contains(arrCode[index].word))
                {
                  
                }
              
                ++index;

                if (arrCode[index].word != "=")
                {
                    errorMassage(arrCode[index]);
                    // return;
                }
                ++index;
             

                if (intVariables.Contains(arrCode[index].word))
                {
                    //if (arrCode[index].word == same)
                    //{
                    //    errorMassage(arrCode[index]);
                    //    ++index;
                    //    return;
                    //}

                    if (counterinfor == arrCode[index].word)
                    {
                        errorMassage(arrCode[index]);
                    }
                }
                else
                {


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);
                        qq1 = anInteger;

                        intvar[] ttemp1 = intVariablesval.ToArray();
                        for (int i = 0; i < ttemp1.Length; i++)
                        {
                            if (ttemp1[i].word == counter)
                            {
                                ttemp1[i].Addres = anInteger;
                            }
                        }
                        intVariablesval.Clear();
                        for (int i = 0; i < ttemp1.Length; i++)
                        {
                            intVariablesval.Add(ttemp1[i]);
                        }

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                        //  ++index;
                        //  return;
                    }

                 

                }
                ++index;
              
                if (arrCode[index].word == semi.ToString())
                {

                }
                //else
                //{
                //    if (arrCode[index].word != semi.ToString())
                //    {
                //        errorMassage(arrCode[index]);
                //        //  ++index;
                //        //  return;
                //    }
                //}


                index++;
          

                if (intVariables.Contains(arrCode[index].word))
                {

                }
         

                ++index;
             
                if (!checkOperators.Contains(arrCode[index].word))
                {
                    errorMassage(arrCode[index]);
                    //  ++index;
                    //  return;
                }
                else
                {
                    if (checkOperators.Contains(arrCode[index].word))
                    {
                        opra = arrCode[index].word;
                    }
                }

                index++;

               
                if (intVariables.Contains(arrCode[index].word))
                {
                    //if (arrCode[index].word == same)
                    //{
                    //    errorMassage(arrCode[index]);
                    //    ++index;
                    //    return;
                    //}

                    intvar[] ttemp1 = intVariablesval.ToArray();
                    for (int i = 0; i < ttemp1.Length; i++)
                    {
                        if (ttemp1[i].word == arrCode[index].word)
                        {
                            qq2 = ttemp1[i].Addres;
                        }
                    }
                    intVariablesval.Clear();
                    for (int i = 0; i < ttemp1.Length; i++)
                    {
                        intVariablesval.Add(ttemp1[i]);
                    }

                    if (counterinfor == arrCode[index].word)
                    {
                        errorMassage(arrCode[index]);
                    }
                }
                else
                {


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);
                        qq2 = anInteger;

                        

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);

                        //intvar[] ttemp1 = intVariablesval.ToArray();
                        //for (int i = 0; i < ttemp1.Length; i++)
                        //{
                        //    if (ttemp1[i].word == arrCode[index].word)
                        //    {
                        //        qq2= ttemp1[i].Addres;
                        //    }
                        //}
                        //intVariablesval.Clear();
                        //for (int i = 0; i < ttemp1.Length; i++)
                        //{
                        //    intVariablesval.Add(ttemp1[i]);
                        //}
                        // ++index;
                        // return;
                    }



                }
                index++;
            

                if (arrCode[index].word == semi.ToString())
                {

                }
                else
                {
                    if (arrCode[index].word != semi.ToString())
                    {
                        errorMassage(arrCode[index]);
                        //  ++index;
                        //  return;
                    }
                }



                index++;
            
                if (!intVariables.Contains(arrCode[index].word))
                {
                    errorMassage(arrCode[index]);
                    // return;
                }
                ++index;
             
                if (arrCode[index].word == "++" || arrCode[index].word == "--")
                {
                    if(arrCode[index].word == "++")
                    {
                        qq3 = 1;
                    }

                    if (arrCode[index].word == "--")
                    {
                        qq3 = -1;
                    }

                }
                else
                {
                    if (arrCode[index].word != "++" && arrCode[index].word != "--")
                    {
                        errorMassage(arrCode[index]);
                        //  ++index;
                        //  return;
                    }
                }





                ++index;

            
                if (arrCode[index].word != ")")
                {
                    errorMassage(arrCode[index]);
                    //  ++index;

                }

                ++index;
         
                if (arrCode[index].word == "{")
                {
                    List<code> forlist = new List<code>();
                    code temp;
                    int count = 1;
                    index++;
                    for (int i = index; i < arrCode.Length; i++)
                    {
                        if (i == arrCode.Length)
                        {
                            errorMassage(arrCode[index]);
                        }
                        else
                        {
                            if (arrCode[i].word == "{")
                            {
                                count++;

                                temp.word = arrCode[i].word;
                                temp.line = arrCode[i].line;
                                forlist.Add(temp);
                            }
                            else
                            {
                                if (arrCode[i].word == "}")
                                {
                                    count--;
                                    if (count == 0)
                                    {
                                        index = i - 1;
                                        i = arrCode.Length;
                                        break;
                                    }
                                    else
                                    {
                                        //count--;
                                        temp.word = arrCode[i].word;
                                        temp.line = arrCode[i].line;
                                        forlist.Add(temp);
                                    }
                                }
                                else
                                {
                                    temp.word = arrCode[i].word;
                                    temp.line = arrCode[i].line;
                                    forlist.Add(temp);
                                }
                            }

                        }
                    }
                    if (count == 0)
                    {
                        code[] forCode = forlist.ToArray();

                        //hnd5l elcode ely b3d el akwaas  l7d 2flt el kos

                        switch(opra)
                        {
                            case "==":

                            if (qq3 == 1)
                            {
                                    var inlist = intVariablesval.FindIndex(c => c.word == counter);

                                    // MessageBox.Show("saئئئئ");
                                    for (int x = intVariablesval[inlist].Addres; x == qq2; x++)
                                {


                                        intvar t;
                                        t.Addres = x;
                                        t.word = counter;
                                      //  var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                        intVariablesval[inlist] = t;



                                        //  MessageBox.Show("saئئئئ");
                                        syntax_ErrorsRun(forCode, ref init);

                                        if (intVariablesval[inlist].Addres != x)
                                            x = intVariablesval[inlist].Addres;

                                }
                            }
                            if (qq3 == -1)
                            {
                                    var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                    for (int x = intVariablesval[inlist].Addres; x == qq2; x--) 
                                {

                                        intvar t;
                                        t.Addres = x;
                                        t.word = counter;
                                       // var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                        intVariablesval[inlist] = t;
                                        //  MessageBox.Show("saئئئئ");
                                        syntax_ErrorsRun(forCode, ref init);
                                        if (intVariablesval[inlist].Addres != x)
                                            x = intVariablesval[inlist].Addres;
                                    }

                            }
                                break;

                            case "<=":
                                if (qq3 == 1)
                                {
                                    var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                    // MessageBox.Show("saئئئئ");
                                    for (int x = intVariablesval[inlist].Addres; x <= qq2; x++)
                                    {
                                        intvar t;
                                        t.Addres = x;
                                        t.word = counter;
                                       // var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                        intVariablesval[inlist] = t;
                                        //  MessageBox.Show("saئئئئ");
                                        syntax_ErrorsRun(forCode, ref init);
                                        if (intVariablesval[inlist].Addres != x)
                                            x = intVariablesval[inlist].Addres;
                                    }
                                }
                                if (qq3 == -1)
                                {
                                    var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                    for (int x = intVariablesval[inlist].Addres; x <= qq2; x--)
                                    {
                                        intvar t;
                                        t.Addres = x;
                                        t.word = counter;
                                        //var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                        intVariablesval[inlist] = t;
                                        //  MessageBox.Show("saئئئئ");
                                        syntax_ErrorsRun(forCode, ref init);
                                        if (intVariablesval[inlist].Addres != x)
                                            x = intVariablesval[inlist].Addres;
                                    }

                                }
                                break;
                            case "<":
                                if (qq3 == 1)
                                {

                                    var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                    // MessageBox.Show("saئئئئ");
                                    for (int x = intVariablesval[inlist].Addres; x < qq2; x++)
                                    {
                                        intvar t;
                                        t.Addres = x;
                                        t.word = counter;
                                       // var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                        intVariablesval[inlist] = t;
                                        //  MessageBox.Show("saئئئئ");
                                        syntax_ErrorsRun(forCode, ref init);
                                        if (intVariablesval[inlist].Addres != x)
                                            x = intVariablesval[inlist].Addres;
                                    }
                                }
                                if (qq3 == -1)
                                {
                                    var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                    for (int x = intVariablesval[inlist].Addres; x < qq2; x--)
                                    {
                                        intvar t;
                                        t.Addres = x;
                                        t.word = counter;
                                        //var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                        intVariablesval[inlist] = t;
                                        //  MessageBox.Show("saئئئئ");
                                        syntax_ErrorsRun(forCode, ref init);
                                        if (intVariablesval[inlist].Addres != x)
                                            x = intVariablesval[inlist].Addres;
                                    }

                                }
                                break;
                            case ">=":
                                if (qq3 == 1)
                                {
                                    var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                    // MessageBox.Show("saئئئئ");
                                    for (int x = intVariablesval[inlist].Addres; x >= qq2; x++)
                                    {
                                        intvar t;
                                        t.Addres = x;
                                        t.word = counter;
                                        //var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                        intVariablesval[inlist] = t;
                                        //  MessageBox.Show("saئئئئ");
                                        syntax_ErrorsRun(forCode, ref init);
                                        if (intVariablesval[inlist].Addres != x)
                                            x = intVariablesval[inlist].Addres;
                                    }
                                }
                                if (qq3 == -1)
                                {
                                    var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                    for (int x = intVariablesval[inlist].Addres; x >= qq2; x--)
                                    {
                                        intvar t;
                                        t.Addres = x;
                                        t.word = counter;
                                        //var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                        intVariablesval[inlist] = t;
                                        //  MessageBox.Show("saئئئئ");
                                        syntax_ErrorsRun(forCode, ref init);
                                        if (intVariablesval[inlist].Addres != x)
                                            x = intVariablesval[inlist].Addres;
                                    }

                                }
                                break;
                            case ">":
                                if (qq3 == 1)
                                {
                                    // MessageBox.Show("saئئئئ");
                                    var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                    for (int x = intVariablesval[inlist].Addres; x > qq2; x++)
                                    {
                                                                                intvar t;
                                        t.Addres = x;
                                        t.word = counter;
                                       // var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                        intVariablesval[inlist] = t;
                                        //  MessageBox.Show("saئئئئ");
                                        syntax_ErrorsRun(forCode, ref init);
                                        if (intVariablesval[inlist].Addres != x)
                                            x = intVariablesval[inlist].Addres;
                                    }
                                }
                                if (qq3 == -1)
                                {
                                    var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                    for (int x = intVariablesval[inlist].Addres; x > qq2; x--)
                                    {
                                        intvar t;
                                        t.Addres = x;
                                        t.word = counter;
                                        //var inlist = intVariablesval.FindIndex(c => c.word == counter);
                                        intVariablesval[inlist] = t;
                                        //  MessageBox.Show("saئئئئ");
                                        syntax_ErrorsRun(forCode, ref init);
                                        if (intVariablesval[inlist].Addres != x)
                                            x = intVariablesval[inlist].Addres;
                                    }

                                }
                                break;


                        }

                        

                        ////////////
                  //      syntax_ErrorsRun(forCode, ref init);

                        intVariables.Remove(counterinfor);
                    }
                    else
                    {
                        code aa;
                        aa.word = "قفلة القوس ل جملة كرر ";
                        aa.line = "تحقق من الاقواس";
                        errorMassage(aa);

                    }
                }
                else
                {
                    if (arrCode[index].word != "{")
                    {
                        errorMassage(arrCode[index]);
                    }
                }


            }


            index++;
            //if (arrCode.Length - 1 <= index)
            //{
            //    code a;
            //    a.line = "الاخير";
            //    a.word = "القوس ل جملة كرر ";
            //    errorMassage(a);
            //    return;
            //}
            if (arrCode[index].word == "}")
            { }
            else
            {
                if (arrCode[index].word != "}")
                {
                    errorMassage(arrCode[index]);
                    ++index;

                }
            }
            //    index++;



            return;
        }


        arrays r;
        void intRule(code[] arrCode, ref int index)
        {
            // string[] arr = WordsArray(txtinput.Text);
            //index++;

            //intVariables.Add(arrCode[index]);

            //  index++;
            string x;
            bool flag = false;
            do
            {
                index++;
                x = arrCode[index].word;
                if (x == "[")
                {
                   

                    index++;


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);
                        r.linght = anInteger;

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                       // ++index;
                       // return;
                    }

                    index++;
                    try
                    {

                        if (arrCode[index].word == "]")
                        {

                        }
                        else
                        {

                            if (arrCode[index].word != "]")
                            {
                                errorMassage(arrCode[index]);
                                ++index;
                               // return;
                            }

                        }

                    }
                    catch
                    {
                        code a;
                        a.line = "الاخير";
                        a.word = "نهاية الكود";

                        errorMassage(a);
                    }
                    index++;

                    if (allGrammar.Contains(arrCode[index].word)||globalgrammerchak.Contains(arrCode[index].word))
                    {

                        if (allGrammar.Contains(arrCode[index].word))
                        {
                            errorMassage(arrCode[index]);
                        }
                        else
                        {
                            if(globalgrammerchak.Contains(arrCode[index].word))
                            {
                                string xx = arrCode[index].word;
                                foreach(code ll in arrCode)
                                {
                                    if(ll.word==xx)
                                    {
                                        code zz;
                                        zz.word = ll.word;
                                        zz.line = ll.line;
                                        errorMassage(zz);
                                    }
                                }
                            }
                        }
                     //   index++;
                     //   return;
                    }
                    else
                    {
                        if (!allGrammar.Contains(arrCode[index].word) &&!globalgrammerchak.Contains(arrCode[index].word))
                        {
                            r.name=arrCode[index].word;
                            arrayIntegar.Add(r);
                           // intVariables.Add(x);
                            addToGrammar(arrCode[index].word);
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }

                }
                else
                {


                    if (allGrammar.Contains(x) || globalgrammerchak.Contains(x))
                    {
                        if (allGrammar.Contains(arrCode[index].word))
                        {
                            errorMassage(arrCode[index]);
                        }
                        else
                        {
                            if (globalgrammerchak.Contains(arrCode[index].word))
                            {
                                string xx = arrCode[index].word;
                                foreach (code ll in arrCode)
                                {
                                    if (ll.word == xx)
                                    {
                                        code zz;
                                        zz.word = ll.word;
                                        zz.line = ll.line;
                                        errorMassage(zz);
                                    }
                                }
                            }
                        }





                        }
                    else
                    {
                        if (!allGrammar.Contains(x)&&!globalgrammerchak.Contains(x))
                        {
                            intVariables.Add(x);
                            addToGrammar(x);
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            } while (flag == true);

            //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
            if (arrCode.Length == index)
            {
                errorMassage(arrCode[index]);
                return;
            }
            else
            {
                if (arrCode[index].word != semi.ToString())
                {
                    // string cc=
                    code bbss;
                    bbss.word = semi.ToString();
                    index--;
                    bbss.line = arrCode[index].line;
                    errorMassage(bbss);

                    return;
                }
            }










            //   index++;









        }


        arrays rr;
        void intRulefun(code[] arrCode, ref int index)
        {
            // string[] arr = WordsArray(txtinput.Text);
            //index++;

            //intVariables.Add(arrCode[index]);

            //  index++;
            string x;
            bool flag = false;
            do
            {
                index++;
                x = arrCode[index].word;
                if (x == "[")
                {


                    index++;


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);
                        rr.linght = anInteger;

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                        // ++index;
                        // return;
                    }

                    index++;
                    try
                    {

                        if (arrCode[index].word == "]")
                        {

                        }
                        else
                        {

                            if (arrCode[index].word != "]")
                            {
                                errorMassage(arrCode[index]);
                                ++index;
                                // return;
                            }

                        }

                    }
                    catch
                    {
                        code a;
                        a.line = "الاخير";
                        a.word = "نهاية الكود";

                        errorMassage(a);
                    }
                    index++;

                    if (allGrammar.Contains(arrCode[index].word)|| localgrammer.Contains(arrCode[index].word))
                    {
                        errorMassage(arrCode[index]);
                        //   index++;
                        //   return;
                    }
                    else
                    {
                        if (!allGrammar.Contains(arrCode[index].word) && !localgrammer.Contains(arrCode[index].word))
                        {
                            rr.name = arrCode[index].word;
                            arrayIntegar.Add(rr);
                            // intVariables.Add(x);
                            // addToGrammar(arrCode[index].word);
                            localgrammer.Add(arrCode[index].word);
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }

                }
                else
                {


                    if (allGrammar.Contains(x)|| localgrammer.Contains(x))
                    {
                        errorMassage(arrCode[index]);
                        //  index++;
                        //   return;
                    }
                    else
                    {
                        if (!allGrammar.Contains(x)&&! localgrammer.Contains(x))
                        {
                            intvar n;
                            n.word = x;
                            n.Addres = 0;
                            funIntVariables.Add(x);
                            // addToGrammar(x);
                            localgrammer.Add(x);
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            } while (flag == true);

            //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
            if (arrCode.Length == index)
            {
                errorMassage(arrCode[index]);
                return;
            }
            else
            {
                if (arrCode[index].word !=semi.ToString())
                {
                    code bbss;
                    bbss.word = semi.ToString();
                    index--;
                    bbss.line = arrCode[index].line;
                    errorMassage(bbss);

                    return;
                }
            }










            //   index++;









        }




        //  arrays r;
        void boolRule(code[] arrCode, ref int index)
        {
            // string[] arr = WordsArray(txtinput.Text);
            //index++;

            //intVariables.Add(arrCode[index]);

            //  index++;
            string x;
            bool flag = false;
            do
            {
                index++;
                x = arrCode[index].word;
                if (x == "[")
                {


                    index++;


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);
                        r.linght = anInteger;

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                        // ++index;
                        // return;
                    }

                    index++;
                    try
                    {

                        if (arrCode[index].word == "]")
                        {

                        }
                        else
                        {

                            if (arrCode[index].word != "]")
                            {
                                errorMassage(arrCode[index]);
                                ++index;
                                // return;
                            }

                        }

                    }
                    catch
                    {
                        code a;
                        a.line = "الاخير";
                        a.word = "نهاية الكود";

                        errorMassage(a);
                    }
                    index++;

                    if (allGrammar.Contains(arrCode[index].word) || globalgrammerchak.Contains(arrCode[index].word))
                    {
                        if (allGrammar.Contains(arrCode[index].word))
                        {
                            errorMassage(arrCode[index]);
                        }
                        else
                        {
                            if (globalgrammerchak.Contains(arrCode[index].word))
                            {
                                string xx = arrCode[index].word;
                                foreach (code ll in arrCode)
                                {
                                    if (ll.word == xx)
                                    {
                                        code zz;
                                        zz.word = ll.word;
                                        zz.line = ll.line;
                                        errorMassage(zz);
                                    }
                                }
                            }
                        }



                    }
                    else
                    {
                        if (!allGrammar.Contains(arrCode[index].word) &&!globalgrammerchak.Contains(arrCode[index].word))
                        {
                            r.name = arrCode[index].word;
                            arrayBool.Add(r);
                            // intVariables.Add(x);
                            addToGrammar(arrCode[index].word);
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }

                }
                else
                {


                    if (allGrammar.Contains(x) || globalgrammerchak.Contains(x))
                    {
                        if (allGrammar.Contains(arrCode[index].word))
                        {
                            errorMassage(arrCode[index]);
                        }
                        else
                        {
                            if (globalgrammerchak.Contains(arrCode[index].word))
                            {
                                string xx = arrCode[index].word;
                                foreach (code ll in arrCode)
                                {
                                    if (ll.word == xx)
                                    {
                                        code zz;
                                        zz.word = ll.word;
                                        zz.line = ll.line;
                                        errorMassage(zz);
                                    }
                                }
                            }
                        }



                    }
                    else
                    {
                        if (!allGrammar.Contains(x)&&!globalgrammerchak.Contains(x))
                        {
                            boolVariables.Add(x);
                            addToGrammar(x);
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            } while (flag == true);

            //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
            if (arrCode.Length == index)
            {
                errorMassage(arrCode[index]);
                return;
            }
            else
            {
                if (arrCode[index].word != semi.ToString())
                {
                    code bbss;
                    bbss.word = semi.ToString();
                    index--;
                    bbss.line = arrCode[index].line;
                    errorMassage(bbss);

                    return;
                }
            }










            //   index++;









        }
        void boolRulefun(code[] arrCode, ref int index)
        {
            // string[] arr = WordsArray(txtinput.Text);
            //index++;

            //intVariables.Add(arrCode[index]);

            //  index++;
            string x;
            bool flag = false;
            do
            {
                index++;
                x = arrCode[index].word;
                if (x == "[")
                {


                    index++;


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);
                        r.linght = anInteger;

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                        // ++index;
                        // return;
                    }

                    index++;
                    try
                    {

                        if (arrCode[index].word == "]")
                        {

                        }
                        else
                        {

                            if (arrCode[index].word != "]")
                            {
                                errorMassage(arrCode[index]);
                                ++index;
                                // return;
                            }

                        }

                    }
                    catch
                    {
                        code a;
                        a.line = "الاخير";
                        a.word = "نهاية الكود";

                        errorMassage(a);
                    }
                    index++;

                    if (allGrammar.Contains(arrCode[index].word) || localgrammer.Contains(arrCode[index].word))
                    {
                        errorMassage(arrCode[index]);
                        //   index++;
                        //   return;
                    }
                    else
                    {
                        if (!allGrammar.Contains(arrCode[index].word)&&!localgrammer.Contains(arrCode[index].word))
                        {
                            r.name = arrCode[index].word;
                            arrayBool.Add(r);
                            localgrammer.Add(arrCode[index].word);
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }

                }
                else
                {


                    if (allGrammar.Contains(x) || localgrammer.Contains(arrCode[index].word))
                    {
                        errorMassage(arrCode[index]);
                        //  index++;
                        //   return;
                    }
                    else
                    {
                        if (!allGrammar.Contains(x) && !localgrammer.Contains(arrCode[index].word))
                        {
                            funBoolVariables.Add(x);
                            // addToGrammar(x);
                            localgrammer.Add(x);
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            } while (flag == true);

            //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
            if (arrCode.Length == index)
            {
                errorMassage(arrCode[index]);
                return;
            }
            else
            {
                if (arrCode[index].word != semi.ToString())
                {
                    code bbss;
                    bbss.word = semi.ToString();
                    index--;
                    bbss.line = arrCode[index].line;
                    errorMassage(bbss);

                    return;
                }
            }










            //   index++;









        }




        arrays temp;
        void floatRule(code[] arrCode, ref int index)
        {
            // string[] arr = WordsArray(txtinput.Text);
            //index++;

            //intVariables.Add(arrCode[index]);

            //index++;
            string x;
            bool flag = false;
            do
            {
                index++;
                x = arrCode[index].word;
                if (x == "[")
                {
                   

                    index++;


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);
                        temp.linght = anInteger;

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                       // ++index;
                       // return;
                    }

                    index++;

                    try
                    {

                        if (arrCode[index].word == "]")
                        {

                        }
                        else
                        {

                            if (arrCode[index].word != "]")
                            {
                                errorMassage(arrCode[index]);
                               ++index;
                              //  return;
                            }

                        }

                    }
                    catch
                    {
                        code a;
                        a.line = "الاخير";
                        a.word = "نهاية الكود";

                        errorMassage(a);
                    }
                    index++;

                    if (allGrammar.Contains(arrCode[index].word) || globalgrammerchak.Contains(arrCode[index].word))
                    {
                        if (allGrammar.Contains(arrCode[index].word))
                        {
                            errorMassage(arrCode[index]);
                        }
                        else
                        {
                            if (globalgrammerchak.Contains(arrCode[index].word))
                            {
                                string xx = arrCode[index].word;
                                foreach (code ll in arrCode)
                                {
                                    if (ll.word == xx)
                                    {
                                        code zz;
                                        zz.word = ll.word;
                                        zz.line = ll.line;
                                        errorMassage(zz);
                                    }
                                }
                            }
                        }



                    }
                    else
                    {
                        if (!allGrammar.Contains(arrCode[index].word)&&!globalgrammerchak.Contains(arrCode[index].word))
                        {
                            temp.name = arrCode[index].word;
                            arrayFloat.Add(temp);
                            // intVariables.Add(x);
                            addToGrammar(arrCode[index].word);
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }

                }
                else
                {
                    if (allGrammar.Contains(x) || globalgrammerchak.Contains(x))
                    {
                        errorMassage(arrCode[index]);
                        // index++;
                    }
                    else
                    {
                        if (!allGrammar.Contains(x)&&!globalgrammerchak.Contains(x))
                        {
                            floatVariables.Add(x);
                            addToGrammar(x);
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            } while (flag == true);

            //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
            if (arrCode.Length == index)
            {
                errorMassage(arrCode[index]);
                return;
            }
            else
            {
                if (arrCode[index].word != semi.ToString())
                {
                    code bbss;
                    bbss.word = semi.ToString();
                    index--;
                    bbss.line = arrCode[index].line;
                    errorMassage(bbss);

                    return;


                }
            }




















        }

        arrays tempzz;
        void floatRulefun(code[] arrCode, ref int index)
        {
            // string[] arr = WordsArray(txtinput.Text);
            //index++;

            //intVariables.Add(arrCode[index]);

            //index++;
            string x;
            bool flag = false;
            do
            {
                index++;
                x = arrCode[index].word;
                if (x == "[")
                {


                    index++;


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);
                        tempzz.linght = anInteger;

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                        // ++index;
                        // return;
                    }

                    index++;

                    try
                    {

                        if (arrCode[index].word == "]")
                        {

                        }
                        else
                        {

                            if (arrCode[index].word != "]")
                            {
                                errorMassage(arrCode[index]);
                                ++index;
                                //  return;
                            }

                        }

                    }
                    catch
                    {
                        code a;
                        a.line = "الاخير";
                        a.word = "نهاية الكود";

                        errorMassage(a);
                    }
                    index++;

                    if (allGrammar.Contains(arrCode[index].word) || localgrammer.Contains(arrCode[index].word))
                    {
                        errorMassage(arrCode[index]);
                        //  index++;
                        // return;
                    }
                    else
                    {
                        if (!allGrammar.Contains(arrCode[index].word)&&!localgrammer.Contains(arrCode[index].word))
                        {
                            tempzz.name = arrCode[index].word;
                            arrayFloat.Add(tempzz);
                          
                            localgrammer.Add(arrCode[index].word);
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }

                }
                else
                {
                    if (allGrammar.Contains(x)|| localgrammer.Contains(x))
                    {
                        errorMassage(arrCode[index]);
                        // index++;
                    }
                    else
                    {
                        if (!allGrammar.Contains(x)&&!localgrammer.Contains(x))
                        {
                            funFloatVariables.Add(x);
                            localgrammer.Add(x);
                           
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            } while (flag == true);

            //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
            if (arrCode.Length == index)
            {
                errorMassage(arrCode[index]);
                return;
            }
            else
            {
                if (arrCode[index].word != semi.ToString())
                {
                    code bbss;
                    bbss.word = semi.ToString();
                    index--;
                    bbss.line = arrCode[index].line;
                    errorMassage(bbss);

                    return;
                }
            }




















        }











        // arrays r;
        void stringRule(code[] arrCode, ref int index)
        {
            // string[] arr = WordsArray(txtinput.Text);
            //index++;

            //intVariables.Add(arrCode[index]);

            //index++;
            string x;
            bool flag = false;
            do
            {
                index++;
                x = arrCode[index].word;
                if (x == "[")
                {
                   

                    index++;


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);
                        r.linght = anInteger;

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                       // ++index;
                      //  return;
                    }

                    index++;
                    try
                    {

                        if (arrCode[index].word == "]")
                        {

                        }
                        else
                        {

                            if (arrCode[index].word != "]")
                            {
                                errorMassage(arrCode[index]);
                                ++index;
                              //  return;
                            }

                        }

                    }
                    catch
                    {
                        code a;
                        a.line = "الاخير";
                        a.word = "نهاية الكود";

                        errorMassage(a);
                    }
                    index++;

                    if (allGrammar.Contains(arrCode[index].word) || globalgrammerchak.Contains(arrCode[index].word))
                    {
                        if (allGrammar.Contains(arrCode[index].word))
                        {
                            errorMassage(arrCode[index]);
                        }
                        else
                        {
                            if (globalgrammerchak.Contains(arrCode[index].word))
                            {
                                string xx = arrCode[index].word;
                                foreach (code ll in arrCode)
                                {
                                    if (ll.word == xx)
                                    {
                                        code zz;
                                        zz.word = ll.word;
                                        zz.line = ll.line;
                                        errorMassage(zz);
                                    }
                                }
                            }
                        }



                    }
                    else
                    {
                        if (!allGrammar.Contains(arrCode[index].word)&&!globalgrammerchak.Contains(arrCode[index].word))
                        {
                            r.name = arrCode[index].word;
                            arrayString.Add(r);
                            // intVariables.Add(x);
                            addToGrammar(arrCode[index].word);
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }

                }
                else
                {
                    if (allGrammar.Contains(x) || globalgrammerchak.Contains(x))
                    {
                        if (allGrammar.Contains(x))
                        {
                            errorMassage(arrCode[index]);
                        }
                        else
                        {
                            if (globalgrammerchak.Contains(x))
                            {
                                string xx = x;
                                foreach (code ll in arrCode)
                                {
                                    if (ll.word == xx)
                                    {
                                        code zz;
                                        zz.word = ll.word;
                                        zz.line = ll.line;
                                        errorMassage(zz);
                                    }
                                }
                            }
                        }



                    }
                    else
                    {
                        if (!allGrammar.Contains(x)&&!globalgrammerchak.Contains(x))
                        {
                            stringVariables.Add(x);
                            addToGrammar(x);
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            } while (flag == true);

            //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
            if (arrCode.Length == index)
            {
                errorMassage(arrCode[index]);
                return;
            }
            else
            {
                if (arrCode[index].word != semi.ToString())
                {
                    code bbss;
                    bbss.word = semi.ToString();
                    index--;
                    bbss.line = arrCode[index].line;
                    errorMassage(bbss);

                    return;
                }
            }























        }
        void stringRulefun(code[] arrCode, ref int index)
        {
            // string[] arr = WordsArray(txtinput.Text);
            //index++;

            //intVariables.Add(arrCode[index]);

            //index++;
            string x;
            bool flag = false;
            do
            {
                index++;
                x = arrCode[index].word;
                if (x == "[")
                {


                    index++;


                    try
                    {
                        int anInteger;
                        anInteger = Convert.ToInt32(arrCode[index].word);
                        r.linght = anInteger;

                    }
                    catch
                    {
                        errorMassage(arrCode[index]);
                        // ++index;
                        //  return;
                    }

                    index++;
                    try
                    {

                        if (arrCode[index].word == "]")
                        {

                        }
                        else
                        {

                            if (arrCode[index].word != "]")
                            {
                                errorMassage(arrCode[index]);
                                ++index;
                                //  return;
                            }

                        }

                    }
                    catch
                    {
                        code a;
                        a.line = "الاخير";
                        a.word = "نهاية الكود";

                        errorMassage(a);
                    }
                    index++;

                    if (allGrammar.Contains(arrCode[index].word) || localgrammer.Contains(arrCode[index].word))
                    {
                        errorMassage(arrCode[index]);
                        // index++;
                        // return;
                    }
                    else
                    {
                        if (!allGrammar.Contains(arrCode[index].word)&& ! localgrammer.Contains(arrCode[index].word))
                        {
                            r.name = arrCode[index].word;
                            arrayString.Add(r);
                            // intVariables.Add(x);
                           // addToGrammar(arrCode[index].word);
                            localgrammer.Add(arrCode[index].word);
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }

                }
                else
                {
                    if (allGrammar.Contains(x)|| localgrammer.Contains(x))
                    {
                        errorMassage(arrCode[index]);
                        // index++;
                    }
                    else
                    {
                        if (!allGrammar.Contains(x) && !localgrammer.Contains(x))
                        {
                            funStringVariables.Add(x);
                           // addToGrammar(x);
                            localgrammer.Add(x);
                        }

                    }




                    // x = arrCode[index];
                    //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
                    if (arrCode.Length - 1 <= index)
                    {
                        errorMassage(arrCode[index]);
                        return;
                    }
                    else
                    {
                        index++;
                        x = arrCode[index].word;
                    }

                    if (x == ",")
                    {
                        flag = true;
                    }
                    else
                    {
                        if (x != ",")
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            } while (flag == true);

            //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
            if (arrCode.Length == index)
            {
                errorMassage(arrCode[index]);
                return;
            }
            else
            {
                if (arrCode[index].word != semi.ToString())
                {
                    code bbss;
                    bbss.word = semi.ToString();
                    index--;
                    bbss.line = arrCode[index].line;
                    errorMassage(bbss);

                    return;
                }
            }























        }
        //  function aa;
        void functionRule(code[] arrCode, ref int index)
        {
            index++;
            function e;
            e.name = arrCode[index].word;
            //   aa.name = "";
        
            if (allGrammar.Contains(arrCode[index].word))
            {
                errorMassage(arrCode[index]);
               // e.name= arrCode[index].word;

            }
            else
            {
                if(!allGrammar.Contains(arrCode[index].word))
                {
                    e.name = arrCode[index].word;
                    addToGrammar(e.name);
                }
                    
                
            }
            index++;
            if(arrCode[index].word!="(")
            {
                errorMassage(arrCode[index]);
            }
            index++;
            if (arrCode[index].word != ")")
            {
                errorMassage(arrCode[index]);
            }
            index++;
            if (arrCode[index].word != "{")
            {
                errorMassage(arrCode[index]);
            }
            else
            {
                if (arrCode[index].word == "{")
                {
                    List<code> funlist = new List<code>();
                    code temp;
                    int count = 1;
                    index++;
                    for (int i = index; i < arrCode.Length; i++)
                    {
                        if (i == arrCode.Length)
                        {
                            errorMassage(arrCode[index]);
                        }
                        else
                        {
                            if (arrCode[i].word == "{")
                            {
                                count++;

                                temp.word = arrCode[i].word;
                                temp.line = arrCode[i].line;
                                funlist.Add(temp);
                            }
                            else
                            {
                                if (arrCode[i].word == "}")
                                {
                                    count--;
                                    if (count == 0)
                                    {
                                        index = i - 1;
                                        i = arrCode.Length;
                                        break;
                                    }
                                    else
                                    {
                                        //count--;
                                        temp.word = arrCode[i].word;
                                        temp.line = arrCode[i].line;
                                        funlist.Add(temp);
                                    }
                                }
                                else
                                {
                                    temp.word = arrCode[i].word;
                                    temp.line = arrCode[i].line;
                                    funlist.Add(temp);
                                }
                            }

                        }
                    }
                    if (count == 0)
                    {
                        code[] forCode = funlist.ToArray();
                        e.body = funlist.ToArray();
                   //     aa.name = e.name;
                   //     aa.body = e.body;
                        //hnd5l elcode ely b3d el akwaas  l7d 2flt el kos
                        syntax_Errors_fun(forCode);
                        List<intvar> templist1 = new List<intvar>();
                        intvar tempint;
                        foreach(string x in funIntVariables)
                        {
                            tempint.word = x;
                            tempint.Addres = 0;
                            templist1.Add(tempint);
                            
                        }
                        List<floatvar> templist2 = new List<floatvar>();
                        floatvar tempFloat;
                        foreach (string x in funFloatVariables)
                        {
                            tempFloat.word = x;
                            tempFloat.value = 0.0;
                            templist2.Add(tempFloat);

                        }
                        List<boolvar> templist3 = new List<boolvar>();
                        boolvar tempbool;
                        foreach (string x in funBoolVariables)
                        {
                            tempbool.word = x;
                            tempbool.value = false;
                            templist3.Add(tempbool);

                        }
                        List<stringvar> templist4 = new List<stringvar>();
                        stringvar tempstring;
                        foreach (string x in funStringVariables)
                        {
                            tempstring.word = x;
                            tempstring.value = " ";
                            templist4.Add(tempstring);

                        }
                        addToGlobalChak(localgrammer);
                        e.boolVar = templist3.ToArray();
                        e.floatVar = templist2.ToArray();
                        e.intVar = templist1.ToArray();
                        e.stringVar = templist4.ToArray();
                        funIntVariables.Clear();
                        funFloatVariables.Clear();
                        funStringVariables.Clear();
                        funBoolVariables.Clear();
                        localgrammer.Clear();
                        //  e.Equals(aa);

                        //    e.stringVar = aa.stringVar;

                        func.Add(e);
                        
                        //intVariables.Remove(counterinfor);
                    }
                    else
                    {
                        code aa;
                        aa.word = "قفلة القوس للدالة ";
                        aa.line = "تحقق من الاقواس";
                        errorMassage(aa);

                    }
                }
                else
                {
                    if (arrCode[index].word != "{")
                    {
                        errorMassage(arrCode[index]);
                    }
                }
            }




        }


       void printRule(code[] arrCode, ref int index)
        {
         

            do
            {
                index++;

                if (arrCode.Length - 1 <= index)
                {
                    code a;
                    a.line = "الاخير";
                    a.word = "لايوجد كود ";
                    errorMassage(a);
                    return;
                }
                if(arrCode[index].word == semi.ToString())
                {
                    index--;
                    break;
                }

                if (arrCode[index].word != "\"")
                {
                    if (intVariables.Contains(arrCode[index].word) | floatVariables.Contains(arrCode[index].word) | stringVariables.Contains(arrCode[index].word)|| funIntVariables.Contains(arrCode[index].word))
                    {

                    }
                    else
                    {
                        if (arrCode[index].word == "سطر")
                        {

                        }
                        else
                        {
                            if (arrCode[index].word == "مسافة" || arrCode[index].word == "مسافه")
                            {

                            }
                            else
                            {
                                errorMassage(arrCode[index]);
                            }
                        }
                    }
                }
                else
                {
                  
                  
                  
                        int aa = index;
                        if (arrCode[index].word == "\"")
                        {
                            string pp = "";
                            index++;
                            if (arrCode.Length - 1 <= index)
                            {
                                code a;
                                a.line = "الاخير";
                                a.word = "لايوجد كود ";
                                errorMassage(a);
                                return;
                            }
                            while (arrCode[index].word != "\"")
                            {

                                if (arrCode[index].word == "\"")
                                {
                                    // index++;
                                    //  break;
                                }
                                else
                                {

                                    pp = pp + arrCode[index].word;
                                    index++;
                                    if (index + 1 >= arrCode.Length)
                                    {
                                        errorMassage(arrCode[aa]);


                                        break;
                                        //return;

                                    }
                                }


                            }
                            //  index++;
                        }
                        else
                        {
                            errorMassage(arrCode[index]);
                            // ++index;
                            // return;
                        }

                    
                }

                index++;
            
                if (arrCode.Length - 1 < index)
                {
                    code bbss;
                    bbss.word = semi.ToString();
                    index--;
                    bbss.line = arrCode[index].line;
                    errorMassage(bbss);
                   
                    return;
                }
                if (arrCode[index].word != ",")
                {
                    index--;
                    break;
                }



            } while (arrCode[index].word != semi.ToString());




            index++;
            if (arrCode.Length  <= index)
            {
                code bbss;
                bbss.word = semi.ToString();
                index--;
                bbss.line = arrCode[index].line;
                errorMassage(bbss);

                return;
            }

            //if (arrCode[index].word !=semi.ToString())
            //{
            //    code bbss;
            //    bbss.word = semi.ToString();
            //    index--;
            //    bbss.line = arrCode[index].line;
            //    errorMassage(bbss);

            //    return;
            //}
           
        }
        void scanRule(code[] arrCode, ref int index)
        {
            index++;

            if (arrCode.Length - 1 <= index)
            {
                code a;
                a.line = "الاخير";
                a.word = "لايوجد كود ";
                errorMassage(a);
                return;
            }

                if (intVariables.Contains(arrCode[index].word) | floatVariables.Contains(arrCode[index].word) | stringVariables.Contains(arrCode[index].word))
                {

                }
                else
                {
                    errorMassage(arrCode[index]);
                }
          
            index++;
            if (arrCode.Length <= index)
            {
                code a;
                a.line = "الاخير";
                a.word = ": ";
                errorMassage(a);
                return;
            }

            if (arrCode[index].word != semi.ToString())
            {
                code bbss;
                bbss.word = semi.ToString();
                index--;
                bbss.line = arrCode[index].line;
                errorMassage(bbss);

                return;
            }

        }
        int varindex, indextemp;
        function inittemp;
        void scanRuleRun(code[] arrCode, ref int index, ref function init)
        {




            if (init.name == "الرئيسية" || init.name == "الرئيسبه")
            {
                // MessageBox.Show("ddd0");
                //functionrulee(arrCode, ref index);


                inittemp = init;
                // : ادخل س 
                index++;

                varindex = index;
                indextemp = index;
                index++;

                //   f1.tempIndex = index;
                indextemp = index;
               //      MessageBox.Show("index abl : " + index);

                //  f1.temp();



                index = arrCode.Length + 1;
                f1.textviow();

            }
            else
            {
                // MessageBox.Show("sdfsd");
                yarab = true;
                inittemp = init;
                // : ادخل س 
                index++;

                varindex = index;
                indextemp = index;
                index++;

                //   f1.tempIndex = index;
                indextemp = index;
                //       MessageBox.Show("index abl : " + index);

                //  f1.temp();



                index = arrCode.Length + 1;
                f1.textviow();




            }

        }

        public void go()
        {
            //  MessageBox.Show("index go : " + indextemp);
            //  code[] aa = WordsArray(txtInput.Text);
            f1.textviow2();
            intvar[] ttemp1 = intVariablesval.ToArray();
            for (int i = 0; i < ttemp1.Length; i++)
            {
                if (ttemp1[i].word == inittemp.body[varindex].word)
                {
                    ttemp1[i].Addres = f1.input;
                }
            }
            intVariablesval.Clear();
            for (int i = 0; i < ttemp1.Length; i++)
            {
                intVariablesval.Add(ttemp1[i]);
            }
            //temp_meanfun
            //    MessageBox.Show("index elkema : " + f1.input);
            syntax_ErrorsRungo(inittemp.body,  indextemp, inittemp);
            if (inittemp.name != "الرئيسية" && inittemp.name != "الرئيسبه")
            {
                function[] heeh = func.ToArray();
                for (int ii = 0; ii < heeh.Length; ii++)
                {


                    if (heeh[ii].name == "الرئيسية" || heeh[ii].name == "الرئيسيه")
                    {

                        //   txtErorr.Text = "لا يوجد أخطاء";



                        // syntax_ErrorsRun(heeh[ii].body, ref heeh[ii]);
                        syntax_ErrorsRungo(heeh[ii].body, temp_meanfun, heeh[ii]);


                    }

                }
                func.Clear();
                for (int ii = 0; ii < heeh.Length; ii++)
                {
                    func.Add(heeh[ii]);
                }


               

            }
        }

        void syntax_ErrorsRungo(code[] arrCode, int index,  function init)
        {
            // int x;
            //  string temp;


            for (int x = index; x < arrCode.Length; x++)
            {


                checkwordrun(arrCode, ref x, ref init);





            }


        }
        void ParseTreeRule(code[]arrCode, ref int index)
        {
            index++;
         //   MessageBox.Show(arrCode[index].word);

            if(arrCode[index].word != "=")
            {
                errorMassage(arrCode[index]);
            }
           

        //    string x;
            bool flag = false;
            do
            {

                index++;

                try
                {
                    int anInteger;
                    anInteger = Convert.ToInt32(arrCode[index].word);


                }
                catch
                {
                    if (intVariables.Contains(arrCode[index].word)|| funIntVariables.Contains(arrCode[index].word))
                    { }
                    else
                    {
                        if (!intVariables.Contains(arrCode[index].word)&&!funIntVariables.Contains(arrCode[index].word))                  
                            errorMassage(arrCode[index]);
                    }
                    //++index;
                    //  return;
                }
                index++;
                if (arrCode.Length  <= index)
                {
                    code bbss;
                    bbss.word = semi.ToString();
                    index--;
                    bbss.line = arrCode[index].line;
                    errorMassage(bbss);

                    return;
                }
                if (!mathOperators.Contains(arrCode[index].word))
                {
                    if (arrCode[index].word != "+" || arrCode[index].word != "-" || arrCode[index].word != "*" || arrCode[index].word != "/")
                        flag = false;
                    else
                        flag = true;
                }
                else
                {
                    flag = true;
                }


            }
            while (flag == true);
            //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
            if (arrCode.Length == index)
            {
                errorMassage(arrCode[index]);
                return;
            }
            else
            {
                if (arrCode[index].word != semi.ToString())
                {
                    errorMassage(arrCode[index]);
                }
            }
           


        }
        string temp2;
      //  int num1=4;
        string[] temparr;
        string variable;
        int oldAdress;
        int x1, y1;
        void ParseTreeRuleRun(code[] arrCode, ref int index)
        {
            variable = arrCode[index].word;
           // MessageBox.Show(variable);
            index++;
            List<string> templist = new List<string>();
           
            if (arrCode[index].word != "=")
            {
                // errorMassage(arrCode[index]);
              //  MessageBox.Show("a");

                return;
            }


            index++;
            bool flag = false;
            try
            {
              //  intvar newValue1;
                int anInteger;
                anInteger = Convert.ToInt32(arrCode[index].word);
                temp2 = arrCode[index].word;
                index++;
                if(arrCode[index].word == semi.ToString())
                {
                  //  int zzz = 0;
                 //   intvar oldValue1;
                    intvar[] ttemp1 = intVariablesval.ToArray();
                    for (int i = 0; i < ttemp1.Length; i++)
                    {
                        if (ttemp1[i].word == variable)
                        {
                            ttemp1[i].Addres = anInteger;
                        }
                    }
                    intVariablesval.Clear();
                    for (int i = 0; i < ttemp1.Length; i++)
                    {
                        intVariablesval.Add(ttemp1[i]);
                    }

                    //foreach (intvar tt in intVariablesval)
                    //{
                    //    if (tt.word ==variable)
                    //    {
                    //        oldAdress = tt.Addres;
                    //    }
                    //  //  zzz++;
                    //}
                    //newValue1.Addres = anInteger;
                    //newValue1.word = variable;
                    //oldValue1.word = variable;
                    //oldValue1.Addres = oldAdress;
                    //intVariablesval.Remove(oldValue1);
                    //intVariablesval.Remove(oldValue1);
                    //intVariablesval.Add(newValue1);
                    //     MessageBox.Show("ac");
                    index--;
                    return;
                }
                index--;
               
            //    MessageBox.Show(temp2);


            }
            catch
            {
                foreach (intvar tt in intVariablesval)
                {
                    if (tt.word == arrCode[index].word)
                    {
                        temp2 = tt.Addres.ToString();
                    }
                  
                }

                //intvar[] ttemp1 = intVariablesval.ToArray();
                //for (int i = 0; i < ttemp1.Length; i++)
                //{
                //    if (ttemp1[i].word == inittemp.body[varindex].word)
                //    {
                //        ttemp1[i].Addres = f1.input;
                //    }
                //}
                //intVariablesval.Clear();
                //for (int i = 0; i < ttemp1.Length; i++)
                //{
                //    intVariablesval.Add(ttemp1[i]);
                //}
            }

            do
            {

               // index++;

            
                index++;
                if (arrCode[index].word == semi.ToString())
                {
                    templist.Add(temp2);
                    break;
                }
                if (!mathOperators.Contains(arrCode[index].word))
                {
                    if (arrCode[index].word != "+" || arrCode[index].word != "-" || arrCode[index].word != "*" || arrCode[index].word != "/")
                    {
                        templist.Add(temp2);
                        flag = false;
                        break;
                    }
                    else
                    {
                        flag = true;
                      //  flag = true;
                      

                        
                    }
                }
                else
                {
                    flag = true;
                    if (arrCode[index].word == "+" )
                    {
                        templist.Add(temp2);
                   //     MessageBox.Show(temp2);
                        templist.Add(arrCode[index].word);
                        index++;
                       temp2 = arrCode[index].word;
                    }
                    else
                    {
                        if (arrCode[index].word == "-")
                        {
                            templist.Add(temp2);
                               
                            templist.Add(arrCode[index].word);
                            index++;
                            temp2 = arrCode[index].word;
                        }
                        else
                        {
                            if (arrCode[index].word == "*")
                            {
                              //  int anInteger1;
                                try
                                {
                                   
                                    x1 = Convert.ToInt32(temp2);
                                    

                                }
                                catch
                                {
                                    foreach (intvar tt in intVariablesval)
                                    {
                                        if (tt.word == variable)
                                        {
                                            x1 = tt.Addres;
                                            
                                        }

                                    }
                                }

                                index++;
                                //  int anInteger2;
                                try
                                {
                                    y1 = Convert.ToInt32(arrCode[index].word);
                                }
                                catch
                                {
                                    foreach (intvar tt in intVariablesval)
                                    {
                                        if (tt.word == arrCode[index].word)
                                        {
                                           y1 = tt.Addres;
                                           // MessageBox.Show(y1.ToString());
                                        }

                                    }
                                }

                                int result = x1 *y1;

                                temp2 = result.ToString();
                              //  MessageBox.Show(temp2);
                            }
                            if (arrCode[index].word == "/")
                            {
                                try
                                {

                                    x1 = Convert.ToInt32(temp2);
                                }
                                catch
                                {
                                    foreach (intvar tt in intVariablesval)
                                    {
                                        if (tt.word == variable)
                                        {
                                            x1 = tt.Addres;
                                        }

                                    }
                                }

                                index++;
                                //  int anInteger2;
                                try
                                {
                                    y1 = Convert.ToInt32(arrCode[index].word);
                                }
                                catch
                                {
                                    foreach (intvar tt in intVariablesval)
                                    {
                                        if (tt.word == arrCode[index].word)
                                        {
                                            y1 = tt.Addres;
                                        }

                                    }
                                }
                                // int aa = 0;
                                try
                                {
                                    float result = x1 / y1;
                                    temp2 = result.ToString();
                                }
                                catch
                                {
                                  
                                }

                                
                            }
                        }


                    }       
                   // flag = true;
                }


            }
            while (flag == true);
           

             temparr = templist.ToArray();
            //   MessageBox.Show("lenth : " + temparr.Length.ToString());

            try
            {
                y1 = Convert.ToInt32(temparr[0]);
            }
            catch
            {
                foreach (intvar tt in intVariablesval)
                {
                    if (tt.word == variable)
                    {
                        y1 = tt.Addres;
                    }

                }
            }
            //  MessageBox.Show(num1.ToString());

            for (int aa = 1; aa < temparr.Length; aa++) 
            {
                if (temparr[aa] == "+")
                {

                    aa++;
                    //       MessageBox.Show("lenth : " + aa.ToString());
                    //    MessageBox.Show("content : " + temparr[aa]);
                    try
                    {

                        x1 = Convert.ToInt32(temparr[aa]);
                    }
                    catch
                    {
                      //  variable = temparr[aa];
                        string variablevalue = temparr[aa];
                        foreach (intvar tt in intVariablesval)
                        {
                            if (tt.word == variablevalue)
                            {
                                x1 = tt.Addres;
                            }

                        }
                    }

                    y1 = y1 + x1;
                    
                // MessageBox.Show(y1.ToString());


                }
                else
                {
                    if (temparr[aa] == "-")
                    {
                        aa++;
                        try
                        {

                            x1 = Convert.ToInt32(temparr[aa]);
                        }
                        catch
                        {
                            //  variable = temparr[aa];
                            string variablevalue = temparr[aa];
                            foreach (intvar tt in intVariablesval)
                            {
                                if (tt.word == variablevalue)
                                {
                                    x1 = tt.Addres;
                                }

                            }
                        }
                        //  MessageBox.Show(num1.ToString());
                        y1 = y1 - x1;
                       // MessageBox.Show(num1.ToString());
                    }
                 
                }
              //  index--;
            }
       //    MessageBox.Show(y1.ToString());
            
   //         intVariablesval.Where(w => w.word == variable).ToList().ForEach(s => s.Addres = num1);
   //         int zzz = 0;
      //      intvar oldValue;
           
        //    foreach (intvar tt in intVariablesval)
        //    {
        //        if (tt.word == variable)
        //        {
        //           oldAdress= tt.Addres;
        //        }
        ////        zzz++;
        //    }


        //    string oldValue = valueFieldValue.ToString();
           

            intvar[] ttemp = intVariablesval.ToArray();
            for (int i = 0; i < ttemp.Length;i++)
            {
                if(ttemp[i].word==variable)
                {
                   // MessageBox.Show("y1="+y1.ToString()+"  variable="+variable+ "  ttemp[i].word="+ ttemp[i].word);
                    ttemp[i].Addres = y1;
                }
            }
            intVariablesval.Clear();
            for (int i = 0; i < ttemp.Length; i++)
            {
                intVariablesval.Add(ttemp[i]);
            }
           

           
            //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
            if (arrCode.Length == index)
            {
           //     errorMassage(arrCode[index]);
                return;
            }
            else
            {
                if (arrCode[index].word != semi.ToString())
                {
                  //  errorMassage(arrCode[index]);
                }
            }



        }
        void ParseTreeRuleRunFun(code[] arrCode, ref int index, ref function init)
        {
            variable = arrCode[index].word;
            index++;
            List<string> templist = new List<string>();

            if (arrCode[index].word != "=")
            {
                // errorMassage(arrCode[index]);
                //  MessageBox.Show("a");

                return;
            }


            index++;
            bool flag = false;
            try
            {
                //  intvar newValue1;
                int anInteger;
                anInteger = Convert.ToInt32(arrCode[index].word);
                temp2 = arrCode[index].word;
                index++;
                if (arrCode[index].word == semi.ToString())
                {
                    //  int zzz = 0;
                    //   intvar oldValue1;

                  //  intvar[] ttemp1 = init.intVar;
                    for (int i = 0; i < init.intVar.Length; i++)
                    {
                        if (init.intVar[i].word == variable)
                        {
                            init.intVar[i].Addres = anInteger;
                        }
                    }
                  

                    //foreach (intvar tt in intVariablesval)
                    //{
                    //    if (tt.word ==variable)
                    //    {
                    //        oldAdress = tt.Addres;
                    //    }
                    //  //  zzz++;
                    //}
                    //newValue1.Addres = anInteger;
                    //newValue1.word = variable;
                    //oldValue1.word = variable;
                    //oldValue1.Addres = oldAdress;
                    //intVariablesval.Remove(oldValue1);
                    //intVariablesval.Remove(oldValue1);
                    //intVariablesval.Add(newValue1);
                    //     MessageBox.Show("ac");
                    index--;
                    return;
                }
                index--;

                //    MessageBox.Show(temp2);


            }
            catch
            {
                for (int i = 0; i < init.intVar.Length; i++)
                {
                    if (init.intVar[i].word == arrCode[index].word)
                    {
                        temp2 = init.intVar[i].Addres.ToString();
                    }
                }

                foreach (intvar tt in intVariablesval)
                {
                    if (tt.word == arrCode[index].word)
                    {
                        temp2 = tt.Addres.ToString();
                    }

                }

            }

            do
            {

                // index++;


                index++;
                if (arrCode[index].word == semi.ToString())
                {
                    templist.Add(temp2);
                    break;
                }
                if (!mathOperators.Contains(arrCode[index].word))
                {
                    if (arrCode[index].word != "+" || arrCode[index].word != "-" || arrCode[index].word != "*" || arrCode[index].word != "/")
                    {
                        templist.Add(temp2);
                        flag = false;
                        break;
                    }
                    else
                    {
                        flag = true;
                        //  flag = true;



                    }
                }
                else
                {
                    flag = true;
                    if (arrCode[index].word == "+")
                    {
                        templist.Add(temp2);
                        //     MessageBox.Show(temp2);
                        templist.Add(arrCode[index].word);
                        index++;
                        temp2 = arrCode[index].word;
                    }
                    else
                    {
                        if (arrCode[index].word == "-")
                        {
                            templist.Add(temp2);
                            //     MessageBox.Show(temp2);
                            templist.Add(arrCode[index].word);
                            index++;
                            temp2 = arrCode[index].word;
                        }
                        else
                        {
                            if (arrCode[index].word == "*")
                            {
                                //  int anInteger1;
                                try
                                {

                                    x1 = Convert.ToInt32(temp2);
                                }
                                catch
                                {
                                    for (int i = 0; i < init.intVar.Length; i++)
                                    {
                                        if (init.intVar[i].word == temp2 )
                                        {
                                           x1= init.intVar[i].Addres;
                                        }
                                    }

                                    foreach (intvar tt in intVariablesval)
                                    {
                                        if (tt.word == temp2)
                                        {
                                            x1 = tt.Addres;
                                        }

                                    }

                                }

                                index++;
                                //  int anInteger2;
                                try
                                {
                                    y1 = Convert.ToInt32(arrCode[index].word);
                                }
                                catch
                                {
                                    for (int i = 0; i < init.intVar.Length; i++)
                                    {
                                        if (init.intVar[i].word == arrCode[index].word)
                                        {
                                           y1= init.intVar[i].Addres;
                                        }
                                    }
                                    foreach (intvar tt in intVariablesval)
                                    {
                                        if (tt.word == arrCode[index].word)
                                        {
                                            y1 = tt.Addres;
                                        }

                                    }

                                }

                                int result = x1 * y1;

                                temp2 = result.ToString();
                            }
                            if (arrCode[index].word == "/")
                            {
                                try
                                {

                                    x1 = Convert.ToInt32(temp2);
                                }
                                catch
                                {
                                    for (int i = 0; i < init.intVar.Length; i++)
                                    {
                                        if (init.intVar[i].word == temp2)
                                        {
                                           x1= init.intVar[i].Addres ;
                                        }
                                    }
                                    foreach (intvar tt in intVariablesval)
                                    {
                                        if (tt.word == temp2)
                                        {
                                            x1 = tt.Addres;
                                        }

                                    }

                                }

                                index++;
                                //  int anInteger2;
                                try
                                {
                                    y1 = Convert.ToInt32(arrCode[index].word);
                                }
                                catch
                                {
                                    for (int i = 0; i < init.intVar.Length; i++)
                                    {
                                        if (init.intVar[i].word == arrCode[index].word)
                                        {
                                           y1= init.intVar[i].Addres;
                                        }
                                    }
                                    foreach (intvar tt in intVariablesval)
                                    {
                                        if (tt.word == arrCode[index].word)
                                        {
                                            y1 = tt.Addres;
                                        }

                                    }

                                }

                                int result = x1 / y1;

                                temp2 = result.ToString();
                            }
                        }


                    }
                    // flag = true;
                }


            }
            while (flag == true);


            temparr = templist.ToArray();
            //   MessageBox.Show("lenth : " + temparr.Length.ToString());

            try
            {
                y1 = Convert.ToInt32(temparr[0]);
            }
            catch
            {
                for (int i = 0; i < init.intVar.Length; i++)
                {
                    if (init.intVar[i].word == temparr[0])
                    {
                       y1= init.intVar[i].Addres;
                    }

                
                }
                foreach (intvar tt in intVariablesval)
                {
                    if (tt.word == temparr[0])
                    {
                        y1 = tt.Addres;
                    }

                }



            }
            //  MessageBox.Show(num1.ToString());

            for (int aa = 1; aa < temparr.Length; aa++)
            {
                if (temparr[aa] == "+")
                {

                    aa++;
                    //       MessageBox.Show("lenth : " + aa.ToString());
                    //    MessageBox.Show("content : " + temparr[aa]);
                    try
                    {

                        x1 = Convert.ToInt32(temparr[aa]);
                    }
                    catch
                    {

                     
                        variable = temparr[aa];

                        for (int i = 0; i < init.intVar.Length; i++)
                        {
                            if (init.intVar[i].word == temparr[aa])
                            {
                              x1=  init.intVar[i].Addres ;
                            }
                        }
                        foreach (intvar tt in intVariablesval)
                        {
                            if (tt.word == temparr[aa])
                            {
                                x1 = tt.Addres;
                            }

                        }

                    }

                    y1 = y1 + x1;
                    //   MessageBox.Show(num1.ToString());


                }
                else
                {
                    if (temparr[aa] == "-")
                    {
                        aa++;
                        try
                        {

                            x1 = Convert.ToInt32(temparr[aa]);
                        }
                        catch
                        {
                            for (int i = 0; i < init.intVar.Length; i++)
                            {
                                if (init.intVar[i].word == temparr[aa])
                                {
                                   x1= init.intVar[i].Addres ;
                                }
                            }
                            foreach (intvar tt in intVariablesval)
                            {
                                if (tt.word == temparr[aa])
                                {
                                    x1 = tt.Addres;
                                }

                            }

                        }
                        //  MessageBox.Show(num1.ToString());
                        y1 = y1 - x1;
                        // MessageBox.Show(num1.ToString());
                    }

                }
                //  index--;
            }
            //    MessageBox.Show(y1.ToString());

            //         intVariablesval.Where(w => w.word == variable).ToList().ForEach(s => s.Addres = num1);
            //         int zzz = 0;
            //      intvar oldValue;
            for (int i = 0; i < init.intVar.Length; i++)
            {
                if (init.intVar[i].word == variable)
                {
                  
                    oldAdress = init.intVar[i].Addres;
                }
            }



            //    string oldValue = valueFieldValue.ToString();
            for (int i = 0; i < init.intVar.Length; i++)
            {
                if (init.intVar[i].word == variable)
                {

                    init.intVar[i].Addres = y1;
                }
            }


         


            //3l4aan lw m7t4 : w kaan el mot8ur a5r 7aga hydy error
            if (arrCode.Length == index)
            {
                //     errorMassage(arrCode[index]);
                return;
            }
            else
            {
                if (arrCode[index].word != semi.ToString())
                {
                    //  errorMassage(arrCode[index]);
                }
            }
        }
        // int qq==0;
        void checkword(code[] arrCode, ref int index)
        {

          

            switch (arrCode[index].word)
            {
                //case "لو":
                //    ifRule(arrCode, ref index);
                //    break;
                //case "كرر":
                //    forRule(arrCode, ref index);
                //    break;
                case "عدد_صحيح":
                    intRule(arrCode, ref index);
                    break;
                case "عدد_عشري":
                    floatRule(arrCode, ref index);
                    break;
                case "عدد_عشرى":
                    floatRule(arrCode, ref index);
                    break;
                case "عدد_ثنائى":
                    boolRule(arrCode, ref index);
                    break;
                case "عدد_ثنائي":
                    boolRule(arrCode, ref index);
                    break;
                case "جمله":
                    stringRule(arrCode, ref index);
                    break;
                case "جملة":
                    stringRule(arrCode, ref index);
                    break;
                case "فارغ":
                   
                        functionRule(arrCode, ref index);
                  
                    
                    break;
                case "تباديل":
                    //         index = switchRule(index);
                    break;
                //case "اطبع":
                //    printRule(arrCode, ref index);
                //    break;
                //case "أطبع":
                //    printRule(arrCode, ref index);
                //    break;
                //case "ادخل":
                //    scanRule(arrCode, ref index);
                //    break;
                //case "أدخل":
                //    scanRule(arrCode, ref index);
                //    break;

                default:
                    if(intVariables.Contains(arrCode[index].word))
                    {
                        ParseTreeRule(arrCode, ref index);
                      //  MessageBox.Show("safsdffs");
                    }
                    break;
                    
            }
            // return index;



        }

        void checkword_fun(code[] arrCode, ref int index )
        {



            switch (arrCode[index].word)
            {
                case "لو":
                    ifRule(arrCode, ref index );
                    break;
                case "كرر":
                    forRule(arrCode, ref index );
                    break;
                case "عدد_صحيح":
                    intRulefun(arrCode, ref index);
                    break;
                case "عدد_عشري":
                    floatRulefun(arrCode, ref index);
                    break;
                case "عدد_عشرى":
                    floatRulefun(arrCode, ref index);
                    break;
                case "عدد_ثنائى":
                    boolRulefun(arrCode, ref index);
                    break;
                case "عدد_ثنائي":
                    boolRulefun(arrCode, ref index);
                    break;
                case "جمله":
                    stringRulefun(arrCode, ref index);
                    break;
                case "جملة":
                    stringRulefun(arrCode, ref index);
                    break;
              
                case "تباديل":
                    //         index = switchRule(index);
                    break;
                case "اطبع":
                    printRule(arrCode, ref index);
                    break;
                case "أطبع":
                    printRule(arrCode, ref index);
                    break;
                case "ادخل":
                    scanRule(arrCode, ref index);
                    break;
                case "أدخل":
                    scanRule(arrCode, ref index);
                    break;

                default:
                    if (intVariables.Contains(arrCode[index].word))
                    {
                        ParseTreeRule(arrCode, ref index);
                        //  MessageBox.Show("safsdffs");
                    }
                    else
                    {
                        if (funIntVariables.Contains(arrCode[index].word))
                        {
                            ParseTreeRule(arrCode, ref index);
                             // MessageBox.Show("safsdffs");
                        }
                        else
                        {
                            foreach (function a in func)
                            {
                                if (a.name == arrCode[index].word)
                                {
                                   // MessageBox.Show("ddd0");
                                    functionrulee(arrCode, ref index);
                                }
                            }
                        }
                    }
                   

                    break;

            }
            // return index;



        }
       void functionrulee(code[] arrCode, ref int index)
        {
            index++;

            if (arrCode[index].word != "(")
            {
                errorMassage(arrCode[index]);

                return;
            }

            index++;

            if (arrCode[index].word != ")")
            {
                errorMassage(arrCode[index]);

                return;
            }
            index++;

            if (arrCode[index].word != semi.ToString())
            {
                errorMassage(arrCode[index]);

                return;
            }



        }

        void syntax_Errors_fun(code[] arrCode )
        {
            // int x;
            //  string temp;


            for (int x = 0; x < arrCode.Length; x++)
            {

                if (!grammer.Contains(arrCode[x].word))
                {
                    if (!intVariables.Contains(arrCode[x].word) && !funIntVariables.Contains(arrCode[x].word)) 
                    {
                        //  checkword(arrCode, ref x);

                        try
                        {
                            if (arrCode[x].word == "}")
                            { }
                            else
                            {
                                if (arrCode[x].word != "}")
                                {

                                    foreach (function a in func)
                                    {
                                        if (a.name == arrCode[x].word)
                                        {
                                            //MessageBox.Show("ddd0");
                                            //functionrulee(arrCode, ref index);
                                            checkword_fun(arrCode, ref x);
                                        }
                                        else
                                        {
                                            errorMassage(arrCode[x]);
                                        }
                                    }
                                    
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        checkword_fun(arrCode, ref x );
                    }

                }
                else
                {
                    checkword_fun(arrCode, ref x);

                }



            }













        }

        void checkwordfor(code[] arrCode, ref int index)
        {



            switch (arrCode[index].word)
            {
                case "لو":
                    ifRule(arrCode, ref index);
                    break;
                case "كرر":
                    forRule(arrCode, ref index);
                    break;
                //case "عدد_صحيح":
                //    intRule(arrCode, ref index);
                //    break;
                //case "عدد_عشري":
                //    floatRule(arrCode, ref index);
                //    break;
                //case "عدد_عشرى":
                //    floatRule(arrCode, ref index);
                //    break;
                //case "عدد_ثنائى":
                //    boolRule(arrCode, ref index);
                //    break;
                //case "عدد_ثنائي":
                //    boolRule(arrCode, ref index);
                //    break;
                //case "جمله":
                //    stringRule(arrCode, ref index);
                //    break;
                //case "جملة":
                //    stringRule(arrCode, ref index);
                //    break;
                //case "فارغ":
                //    functionRule(arrCode, ref index);
                //    break;
                case "تباديل":
                    //         index = switchRule(index);
                    break;
                case "اطبع":
                    printRule(arrCode, ref index);
                    break;
                case "أطبع":
                    printRule(arrCode, ref index);
                    break;
                case "ادخل":
                    scanRule(arrCode, ref index);
                    break;
                case "أدخل":
                    scanRule(arrCode, ref index);
                    break;

                default:
                    if (intVariables.Contains(arrCode[index].word))
                    {
                        ParseTreeRule(arrCode, ref index);
                        //  MessageBox.Show("safsdffs");
                    }
                    else
                    {

                        foreach (function a in func)
                        {
                            if (a.name == arrCode[index].word)
                            {
                                MessageBox.Show("ddd0");
                                functionrulee(arrCode, ref index);
                            }
                        }
                    }
                    break;

            }
            // return index;



        }


        void syntax_Errors(code[] arrCode)
        {
            // int x;
            //  string temp;

          //  public int y;
            for (int x = 0; x < arrCode.Length; x++)
            {

                if (!grammer.Contains(arrCode[x].word))
                {
                    if (!intVariables.Contains(arrCode[x].word))
                    {
                      //  checkword(arrCode, ref x);

                        try
                        {
                            if (arrCode[x].word == "}")
                            { }
                            else
                            {
                                if (arrCode[x].word != "}")
                                {

                                   // errorMassage(arrCode[x]);
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        checkword(arrCode, ref x);
                    }

                }
                else
                {
                    checkword(arrCode, ref x);

                }



            }













        }

        void syntax_Errors_for(code[] arrCode)
        {
            // int x;
            //  string temp;


            for (int x = 0; x < arrCode.Length; x++)
            {

                if (!grammer.Contains(arrCode[x].word))
                {
                    if (!intVariables.Contains(arrCode[x].word))
                    {
                        //  checkword(arrCode, ref x);

                        try
                        {
                            if (arrCode[x].word == "}")
                            { }
                            else
                            {
                                if (arrCode[x].word != "}")
                                {

                                    errorMassage(arrCode[x]);
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        checkwordfor(arrCode, ref x);
                    }

                }
                else
                {
                    checkwordfor(arrCode, ref x);

                }



            }













        }

        protected override void WndProc(ref Message m)
        {
            FormWindowState previousWindowState = this.WindowState;

            base.WndProc(ref m);

            FormWindowState currentWindowState = this.WindowState;

            if (previousWindowState != currentWindowState && currentWindowState == FormWindowState.Maximized)
            {
                label1.Hide();
                txtErorr.Hide();
                groupBox1.Width = 1915;
                groupBox1.Height = 950;
                txtInput.Height = 938;
                txtInput.Width = 1865;
                arkaaam = 28;
            }

            if (previousWindowState != currentWindowState && currentWindowState == FormWindowState.Normal)
            {
                label1.Hide();
                txtErorr.Hide();
                groupBox1.Width = 1222;
                groupBox1.Height = 715;
                txtInput.Height = 700;
                txtInput.Width = 1172;
                arkaaam = 21;

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Today.ToShortDateString();
            LineNumberTextBox.Font = txtInput.Font;
            txtInput.Select();
            AddLineNumbers();
            label1.Hide();
            txtErorr.Hide();
            groupBox1.Width = 1222;
            groupBox1.Height = 715;
            txtInput.Height = 700;
            txtInput.Width = 1172;
            //toolStrip2.BringToFront();
        }
      public  void aaaaaa()
        {
            label1.Hide();
            txtErorr.Hide();
            groupBox1.Width = 1222;
            groupBox1.Height = 715;
            txtInput.Height = 700;
            txtInput.Width = 1172;
        }
     public   static void share ()
        {

            Form1 a = new Form1();
            a.aaaaaa();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = txtInput.GetPositionFromCharIndex(txtInput.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
            int index = txtInput.SelectionStart;
            int line = txtInput.GetLineFromCharIndex(index);
         //   label1.Text = "cursor at line " + line.ToString();
            toolStripStatusLabel3.Text = "  السطر الحالى رقم  " + line.ToString();
        }

        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_FontChanged(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = txtInput.Font;
            txtInput.Select();
            AddLineNumbers();
        }

        private void LineNumberTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            txtInput.Select();
            LineNumberTextBox.DeselectAll();
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
         //   richTextBox1.Text = richTextBox1.Text + "asda";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtInput.LoadFile(openFileDialog.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtInput.SaveFile(saveFileDialog.FileName);

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        FormWindowState LastWindowState = FormWindowState.Minimized;

        // When window state changes

        Point a;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;


                if (WindowState == FormWindowState.Maximized)
                {

                    // Maximized!
                 
                    groupBox1.Width = 1915;
                    groupBox1.Height = 775;
                    txtInput.Height = 770;
                    txtInput.Width = 1865;
                    label1.Show();
                    txtErorr.Show();
                    a.X = 5;
                    a.Y = 838;
                    txtErorr.Location = a;
                    txtErorr.Width = 1908;
                    a.X = 1840;
                    a.Y = 818;
                    label1.Location = a;
                   
                 
                    arkaaam = 28;
                }
                if (WindowState == FormWindowState.Normal)
                {
                    txtInput.Width = 1181;
                    txtInput.Height = 520;
                    groupBox1.Width = 1229;
                    groupBox1.Height = 537;
                    label1.Show();
                    txtErorr.Show();
                
                    // Restored!
                }
            }
            //txtInput.Width= 1181;
            //txtInput.Height = 505;
            //groupBox1.Width= 1229;
            //groupBox1.Height = 522;
            //label1.Show();
            //txtErorr.Show();
            clear();
            syntax_Errors(WordsArray(txtInput.Text));

            if (txtErorr.Text == "" && txtInput.Text != "")
            {
                foreach (function ii in func)
                {
                    if (ii.name == "الرئيسية")
                    {
                        foreach (function iii in func)
                        {
                            if ( iii.name == "الرئيسيه")
                            {

                                //   txtErorr.Text = "لا يوجد أخطاء";
                                errorMassage("يوجد دالتان رئيسيتان");
                               // break;
                                return;

                            }

                        }
                        txtErorr.Text = "لا يوجد أخطاء";
                    
                        break;
                    }
                    else
                    {
                        if (ii.name == "الرئيسيه")
                        {
                            foreach (function iii in func)
                            {
                                if (iii.name == "الرئيسية")
                                {

                                    //   txtErorr.Text = "لا يوجد أخطاء";
                                    errorMassage("يوجد دالتان رئيسيتان");
                                    return;
    

                            }

                            }
                            txtErorr.Text = "لا يوجد أخطاء";
                            break;
                        }
                        else
                        {
                            errorMassage("لا يوجد الدالة الرئيسية");
                        }
                    }
                }
               
            }
            else
                if (txtErorr.Text == "" && txtInput.Text == "")
            {
                txtErorr.Text = "لا يوجد كود ";
            }
       
            bugrun = true;
            txtel8ur = false;
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtInput.LoadFile(openFileDialog.FileName);
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtInput.SaveFile(saveFileDialog.FileName);

            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            if (txtInput.Text == "")
                return;
             DialogResult result = MessageBox.Show("هل تريد حفظ الملف الحالى ؟", "تحزير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                // Closes the parent form.
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtInput.SaveFile(saveFileDialog.FileName);

                }
                
              //  this.Close();

            }
         txtInput.Clear();
         //   MessageBox.Show("هل تريد حفظ الملف الحالى ؟", "تحزير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
           
        }

        private void معاينةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear();
            syntax_Errors(WordsArray(txtInput.Text));

            if (txtErorr.Text == "" && txtInput.Text != "")
            {
                txtErorr.Text = "لا يوجد أخطاء";
            }
            else
                if (txtErorr.Text == "" && txtInput.Text == "")
            {
                txtErorr.Text = "لا يوجد كود ";
            }
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtInput.Text);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtInput.Text);
            txtInput.Clear();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            txtInput.Text = Clipboard.GetText();
        }
        void printRuleRun(code[] arrCode, ref int index , ref function init)
        {
            string pp = "";
            do
            {


                index++;

            //    string pp = "";
                //if (arrCode.Length - 1 <= index)
                //{
                //    code a;
                //    a.line = "الاخير";
                //    a.word = "لايوجد كود ";
                //    errorMassage(a);
                //    return;
                //}

                if (arrCode[index].word != "\"")
                {

                    if (arrCode[index].word == "مسافة" || arrCode[index].word == "مسافه")
                    {
                        string m = f1.shangeout();
                        f1.shangeout(m + " ");
                    }
                    else
                    {
                        if (arrCode[index].word == "سطر")
                        {
                            string m = f1.shangeout();
                            f1.shangeout(m + "\n");
                        }
                        else
                        {


                            if (intVariables.Contains(arrCode[index].word))
                            {
                                foreach (intvar x in intVariablesval)
                                {
                                    if (x.word == arrCode[index].word)
                                    {
                                        //AllocConsole();
                                        //Console.Write(x.Addres + "  ");
                                        string m = f1.shangeout();
                                        f1.shangeout(m + x.Addres);
                                    }
                                }
                            }
                            else
                            {
                                for(int i =0; i < init.intVar.Length;i++)
                                {
                                    if(init.intVar[i].word== arrCode[index].word)
                                    {
                                        string m = f1.shangeout();
                                        f1.shangeout(m + init.intVar[i].Addres);
                                    }
                                }
                            }

                            if (intVariables.Contains(arrCode[index].word) | floatVariables.Contains(arrCode[index].word) | stringVariables.Contains(arrCode[index].word))
                            {

                            }
                            else
                            {
                                // errorMassage(arrCode[index]);
                            }
                        }
                    }
                }
                else
                {
                    int aa = index;
                    if (arrCode[index].word == "\"")
                    {
                        index++;

                        while (arrCode[index].word != "\"")
                        {

                            if (arrCode[index].word == "\"")
                            {
                                // index++;
                                //  break;
                            }
                            else
                            {

                                pp = pp + " " + arrCode[index].word;
                                index++;
                                //if (index + 1 >= arrCode.Length)
                                //{
                                //    errorMassage(arrCode[aa]);


                                //    break;
                                //    //return;

                                //}
                            }


                        }
                        //  index++;
                    }
                    else
                    {
                        // errorMassage(arrCode[index]);
                        // ++index;
                        // return;
                    }
                    //   AllocConsole();
                    //    Console.Write(pp + "  ");
                    string m = f1.shangeout();
                    f1.shangeout(m + pp);
                    pp = "";
                    //  Console.WriteLine("dsdsdsdd");

                    //  string xx = Console.ReadLine();


                }
                index++;
                if(arrCode[index].word==",")
                {

                }
                else
                {
                    if (arrCode[index].word != ",")
                    {
                        index++;
                        break;
                    }
                }
               
                //if (arrCode.Length <= index)
                //{
                //    code a;
                //    a.line = "الاخير";
                //    a.word = ": ";
                //    errorMassage(a);
                //    return;
                //}

                //if (arrCode[index].word != semi.ToString())
                //{
                //    errorMassage(arrCode[index]);
                //}
            } while (arrCode[index].word != semi.ToString());

            index--;

        }
      void  tagheez()
        {
            intvar temp;
            intVariablesval.Clear();
            foreach (string x in intVariables)
            {
                temp.word = x;
                temp.Addres = 0;
                intVariablesval.Add(temp);
            }



        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {

           
         //   f1.shangeout("dsvfdsfdx");
            if (bugrun == true&&txtel8ur==false)
            {
                if (txtErorr.Text == "لا يوجد أخطاء")
                {
                    runstop = true;
                    tagheez();
                 //   f1.Activate();
                   f1.Show();

                    syntax_ErrorsRunGlobal(WordsArray(txtInput.Text));
                    //  var handle = GetConsoleWindow();


                    //  ShowWindow(handle, SW_SHOW);
                    function[] heeh = func.ToArray();
                    for(int ii = 0; ii<heeh.Length;ii++)
                    { 
                        
                   
                        if (heeh[ii].name == "الرئيسية" || heeh[ii].name== "الرئيسيه")
                        {

                            //   txtErorr.Text = "لا يوجد أخطاء";
                      


                            syntax_ErrorsRun(heeh[ii].body, ref heeh[ii]);

                           
                        }
                     
                    }
                    func.Clear();
                    for (int ii = 0; ii < heeh.Length; ii++)
                    {
                        func.Add(heeh[ii]);
                    }



                        //Console.Title = "الناتج";
                    }
                else
                {
                    if (txtErorr.Text == "لا يوجد كود ")
                    {
                        MessageBox.Show("لايوجد شفيرة برمجية للتشغيل !!!", "تحزير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("برجاء تصحيح الاخطاء قبل التشغيل !!!", "تحزير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                if(txtel8ur==true)
                    MessageBox.Show("برجاء الضغط على تصحيح الاخطاء بعد التغيير ", "تحزير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                MessageBox.Show("برجاء الضغط على تصحيح الاخطاء قبل التشغيل ", "تحزير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bugrun = false;

        }
        void syntax_ErrorsRun(code[] arrCode ,ref function init)
        {
            // int x;
            //  string temp;
           
      
            for (int x = 0; x < arrCode.Length; x++)
            {

              
                    checkwordrun(arrCode, ref x,ref init);

              



           }


        }
        void syntax_ErrorsRunGlobal(code[] arrCode)
        {
            // int x;
            //  string temp;


            for (int x = 0; x < arrCode.Length; x++)
            {


                checkwordrunGlobal(arrCode, ref x);





            }


        }
        void checkwordrunGlobal(code[] arrCode, ref int index)
        {
            //switch (arrCode[index].word)
            //{
            //    case "لو":
            //        ifRuleRun(arrCode, ref index, ref init);
            //        break;
            //    case "كرر":
            //        forRuleRun(arrCode, ref index, ref init);
            //        break;
                //case "عددصحيح":
                //    intRule(arrCode, ref index);
                //    break;
                //case "عددعشري":
                //    floatRule(arrCode, ref index);
                //    break;
                //case "عددعشرى":
                //    floatRule(arrCode, ref index);
                //    break;
                //case "جمله":
                //    stringRule(arrCode, ref index);
                //    break;
                //case "جملة":
                //    stringRule(arrCode, ref index);
                //    break;
                //case "خال":
                //    functionRule(arrCode, ref index);
                //    break;
                //case "تباديل":
                //    //         index = switchRule(index);
                //    break;
                //case "اطبع":
                //    printRuleRun(arrCode, ref index, ref init);
                //    break;
                //case "أطبع":
                //    printRuleRun(arrCode, ref index, ref init);
                //    break;
                //case "ادخل":
                //    printRule(arrCode, ref index);
                //    break;
                //case "أدخل":
                //    printRule(arrCode, ref index);
                //    break;

                //default:


                    if (intVariables.Contains(arrCode[index].word))
                    {
                        ParseTreeRuleRun(arrCode, ref index);
                        // MessageBox.Show("safsdffs");
                    }
                    //foreach (intvar a in init.intVar)
                    //{
                    //    if (a.word == arrCode[index].word)
                    //    {
                    //        ParseTreeRuleRunFun(arrCode, ref index, ref init);
                    //    }
                    //}

                    //break;
            //}
            // return index;



        }
        void checkwordrun(code[] arrCode, ref int index,ref function init)
        {
            switch (arrCode[index].word)
            {
                case "لو":
                    ifRuleRun(arrCode, ref index ,ref init);
                    break;
                case "كرر":
                    forRuleRun(arrCode, ref index, ref init);
                    break;
                //case "عددصحيح":
                //    intRule(arrCode, ref index);
                //    break;
                //case "عددعشري":
                //    floatRule(arrCode, ref index);
                //    break;
                //case "عددعشرى":
                //    floatRule(arrCode, ref index);
                //    break;
                //case "جمله":
                //    stringRule(arrCode, ref index);
                //    break;
                //case "جملة":
                //    stringRule(arrCode, ref index);
                //    break;
                //case "خال":
                //    functionRule(arrCode, ref index);
                //    break;
                //case "تباديل":
                //    //         index = switchRule(index);
                //    break;
                case "اطبع":
                    printRuleRun(arrCode, ref index ,ref init);
                    break;
                case "أطبع":
                    printRuleRun(arrCode, ref index, ref init);
                    break;
                case "ادخل":
                    scanRuleRun(arrCode, ref index, ref init);
                    break;
                case "أدخل":
                    scanRuleRun(arrCode, ref index, ref init);
                    break;

                default:
                    if (intVariables.Contains(arrCode[index].word))
                    {
                        ParseTreeRuleRun(arrCode, ref index);
                        // MessageBox.Show("safsdffs");
                    }
                    else
                    {
                        function[] heeh = func.ToArray();
                        for (int ii = 0; ii < heeh.Length; ii++)
                        {


                            if (heeh[ii].name == arrCode[index].word)
                            {

                                //   txtErorr.Text = "لا يوجد أخطاء";



                                functionrulerun(arrCode, ref index, ref init);


                            }

                        }
                        func.Clear();
                        for (int ii = 0; ii < heeh.Length; ii++)
                        {
                            func.Add(heeh[ii]);
                        }



                        foreach (intvar a in init.intVar)
                        {
                            if (a.word == arrCode[index].word)
                            {
                                ParseTreeRuleRunFun(arrCode, ref index, ref init);
                            }
                        }

                     
                    }

                  
                   


                    break;
            }
            // return index;



        }
     
      void functionrulerun(code[] arrCode, ref int index, ref function init)
        {



            temp_meanfun = index + 3;

            function[] heeh = func.ToArray();
            for (int ii = 0; ii < heeh.Length; ii++)
            {


                if (heeh[ii].name == arrCode[index].word )
                {

                    //   txtErorr.Text = "لا يوجد أخطاء";



                    syntax_ErrorsRun(heeh[ii].body, ref heeh[ii]);

                    


                }

            }
            func.Clear();
            for (int ii = 0; ii < heeh.Length; ii++)
            {
                func.Add(heeh[ii]);
            }
            index++;
            index++;
            index++;

            if (yarab == true)
            {
                index = arrCode.Length;
                yarab = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

          

        }
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();
        public void setset()
        {
            label1.Hide();
            txtErorr.Hide();
            groupBox1.Width = 1226;
            groupBox1.Height = 701;
            txtInput.Height = 679;
            txtInput.Width = 1170;
        }
      
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
        
            //  Console.Clear();
            if (runstop ==true)
            {
                //     Console.Out.Close();
                ///   Console.Clear();
                //    FreeConsole();
                // Console.Clear();
                f1.clearout();
                f1.Hide();
                
             //   var handle = GetConsoleWindow();

                // Hide
              //  Console.Clear();
              //  ShowWindow(handle, SW_HIDE);
              //  Console.Clear();
                runstop = false;
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            
        }

        private void المساعدةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (runstop == true)
            {
                //     Console.Out.Close();
                Console.Clear();
                //    FreeConsole();

                var handle = GetConsoleWindow();

                // Hide
                ShowWindow(handle, SW_HIDE);
                runstop = false;
            }
        }

        bool lalala = false;
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.CheckKeyword("لو", Color.Blue, 0);
            this.CheckKeyword("عدد_صحيح", Color.Blue, 0);
            this.CheckKeyword("عدد_عشري", Color.Blue, 0);
            this.CheckKeyword("عدد_عشرى", Color.Blue, 0);
            this.CheckKeyword("عدد_ثنائي", Color.Blue, 0);
            this.CheckKeyword("عدد_ثنائى", Color.Blue, 0);
            this.CheckKeyword("كرر", Color.Blue, 0);
            this.CheckKeyword("اطبع", Color.Blue, 0);
            this.CheckKeyword("أطبع", Color.Blue, 0);
            this.CheckKeyword("ادخل", Color.Blue, 0);
            this.CheckKeyword("أدخل", Color.Blue, 0);
            this.CheckKeyword("جملة", Color.Blue, 0);
            this.CheckKeyword("غيرذلك", Color.Blue, 0);
            this.CheckKeyword("جملة", Color.Blue, 0);
            this.CheckKeyword("جمله", Color.Blue, 0);
            this.CheckKeyword("صح", Color.Blue, 0);
            this.CheckKeyword("خطا", Color.Blue, 0);
            this.CheckKeyword("خطأ", Color.Blue, 0);
            this.CheckKeyword("سطر", Color.MediumSeaGreen, 0);
            this.CheckKeyword("مسافة", Color.MediumSeaGreen, 0);
            this.CheckKeyword("مسافه", Color.MediumSeaGreen, 0);
            this.CheckKeyword("فارغ", Color.Blue, 0);
            this.CheckKeyword("\"", Color.Red, 0);
            this.CheckKeyword(semi.ToString(), Color.Brown, 0);// lalala = true;


        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            lalala = true;
            this.CheckKeyword("لو", Color.Blue, 0);
            this.CheckKeyword("عدد_صحيح", Color.Blue, 0);
            this.CheckKeyword("عدد_عشري", Color.Blue, 0);
            this.CheckKeyword("عدد_عشرى", Color.Blue, 0);
            this.CheckKeyword("عدد_ثنائي", Color.Blue, 0);
            this.CheckKeyword("عدد_ثنائى", Color.Blue, 0);
            this.CheckKeyword("كرر", Color.Blue, 0);
            this.CheckKeyword("اطبع", Color.Blue, 0);
            this.CheckKeyword("أطبع", Color.Blue, 0);
            this.CheckKeyword("ادخل", Color.Blue, 0);
            this.CheckKeyword("أدخل", Color.Blue, 0);
            this.CheckKeyword("جملة", Color.Blue, 0);
            this.CheckKeyword("غيرذلك", Color.Blue, 0);
            this.CheckKeyword("جملة", Color.Blue, 0);
            this.CheckKeyword("جمله", Color.Blue, 0);
            this.CheckKeyword("صح", Color.Blue, 0);
            this.CheckKeyword("خطا", Color.Blue, 0);
            this.CheckKeyword("خطأ", Color.Blue, 0);
            this.CheckKeyword("سطر", Color.MediumSeaGreen, 0);
            this.CheckKeyword("مسافة", Color.MediumSeaGreen, 0);
            this.CheckKeyword("مسافه", Color.MediumSeaGreen, 0);
            this.CheckKeyword("فارغ", Color.Blue, 0);
            this.CheckKeyword("\"", Color.Red, 0);
            this.CheckKeyword(semi.ToString(), Color.Brown, 0);// lalala = true;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.CheckKeyword("لو", Color.Blue, 0);
            this.CheckKeyword("عدد_صحيح", Color.Blue, 0);
            this.CheckKeyword("عدد_عشري", Color.Blue, 0);
            this.CheckKeyword("عدد_عشرى", Color.Blue, 0);
            this.CheckKeyword("عدد_ثنائي", Color.Blue, 0);
            this.CheckKeyword("عدد_ثنائى", Color.Blue, 0);
            this.CheckKeyword("كرر", Color.Blue, 0);
            this.CheckKeyword("اطبع", Color.Blue, 0);
            this.CheckKeyword("أطبع", Color.Blue, 0);
            this.CheckKeyword("ادخل", Color.Blue, 0);
            this.CheckKeyword("أدخل", Color.Blue, 0);
            this.CheckKeyword("جملة", Color.Blue, 0);
            this.CheckKeyword("غيرذلك", Color.Blue, 0);
            this.CheckKeyword("جملة", Color.Blue, 0);
            this.CheckKeyword("جمله", Color.Blue, 0);
            this.CheckKeyword("صح", Color.Blue, 0);
            this.CheckKeyword("خطا", Color.Blue, 0);
            this.CheckKeyword("خطأ", Color.Blue, 0);
            this.CheckKeyword("سطر", Color.Blue, 0);
            this.CheckKeyword("مسافة", Color.Blue, 0);
            this.CheckKeyword("مسافه", Color.Blue, 0);
            this.CheckKeyword(semi.ToString(), Color.Brown, 0);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            lalala = false;
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    MessageBox.Show("enter");
            //}
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void الصيغةToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }
        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.txtInput.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.txtInput.SelectionStart;

                while ((index = this.txtInput.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.txtInput.Select((index + startIndex), word.Length);
                    this.txtInput.SelectionColor = color;
                    this.txtInput.Select(selectStart, 0);
                    this.txtInput.SelectionColor = Color.Black;
                }
            }
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            txtel8ur = true;

            if (lalala == true)
            {
                this.CheckKeyword("لو", Color.Blue, 0);
                this.CheckKeyword("عدد_صحيح", Color.Blue, 0);
                this.CheckKeyword("عدد_عشري", Color.Blue, 0);
                this.CheckKeyword("عدد_عشرى", Color.Blue, 0);
                this.CheckKeyword("عدد_ثنائي", Color.Blue, 0);
                this.CheckKeyword("عدد_ثنائى", Color.Blue, 0);
                this.CheckKeyword("كرر", Color.Blue, 0);
                this.CheckKeyword("اطبع", Color.Blue, 0);
                this.CheckKeyword("أطبع", Color.Blue, 0);
                this.CheckKeyword("ادخل", Color.Blue, 0);
                this.CheckKeyword("أدخل", Color.Blue, 0);
                this.CheckKeyword("جملة", Color.Blue, 0);
                this.CheckKeyword("غيرذلك", Color.Blue, 0);
                this.CheckKeyword("جملة", Color.Blue, 0);
                this.CheckKeyword("جمله", Color.Blue, 0);
                this.CheckKeyword("صح", Color.Blue, 0);
                this.CheckKeyword("خطا", Color.Blue, 0);
                this.CheckKeyword("خطأ", Color.Blue, 0);
                this.CheckKeyword("سطر", Color.Blue, 0);
                this.CheckKeyword("مسافة", Color.Blue, 0);
                this.CheckKeyword("مسافه", Color.Blue, 0);
                this.CheckKeyword(semi.ToString(), Color.Brown, 0);
            }


            
            //  txtErorr.Text = txtErorr.Text + " a";

        }

        private void الدليلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2 aa = new form2();
            aa.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    AllocConsole();
        //}
        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();























    }
}
