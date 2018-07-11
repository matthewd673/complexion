using System;
using System.IO;

namespace complexion
{

    //^ = open file
    //_ = close file
    //> (<) = find value greater than [object number]
    //< (>) = find value less than [object number]
    //= = find equal to [object number]
    //. = (added later) write to file (overwrites)
    //$ = (added later) file value
    //MINIMUM VALUE IS 0

    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                compile(File.ReadAllText(args[0]));
            }
            else
            {
                Console.WriteLine("No file provided");
            }
        }

        static void compile(String inputCode)
        {

            String[] cleanCode = inputCode.Split(new char[] { '\t', '\r', '\f', '\v','\\' }, StringSplitOptions.RemoveEmptyEntries);
            String code = "";
            for(int i = 0; i < cleanCode.Length; i++)
            {
                code += cleanCode[i];
            }

            String[] lines = code.Split("\n");
            
            String currentFile = "";
            int currentValue = 0;
            int fileValue = 0;
            
            bool abort = false;

            for(int i = 0; i < lines.Length; i++)
            {
                String[] commands;
                if(lines[i].Contains(" "))
                    commands = lines[i].Split(" ");
                else
                    commands = new String[] { lines[i] };

                Console.Write(lines[i] + " ");

                switch(commands[0])
                {
                    case "^":
                        //open
                        if(commands.Length > 1)
                        {
                            currentFile = commands[1];
                            if(File.Exists(currentFile)) //you CAN open files that don't exist (just setting the currentFile value)
                            {
                                String file = File.ReadAllText(currentFile);
                                if(!int.TryParse(file, out fileValue))
                                    Console.WriteLine(currentFile + " does not contain an integer value");
                                //fileValue = Convert.ToInt32(File.ReadAllText(currentFile));
                            }
                        }
                        else
                            abort = true;
                        break;
                    case "_":
                        //close
                        currentFile = "";
                        fileValue = 0;
                        break;
                    case ".":
                        //write
                        if(currentFile != "")
                        {
                            File.WriteAllText(currentFile, currentValue.ToString());
                        }
                        else
                        {
                            abort = true;
                        }
                        break;
                    case ">":
                        //greater
                        if(commands.Length > 1)
                            if(commands[1] != "$")
                                currentValue = Convert.ToInt32(commands[1]) + 1;
                            else
                                currentValue = fileValue + 1;
                        else
                            currentValue++;
                        break;
                    case "<":
                        //less
                        if(commands.Length > 1)
                            if(commands[1] != "$")
                                currentValue = Convert.ToInt32(commands[1]) - 1;
                            else
                                currentValue = fileValue - 1;
                        else
                            currentValue--;
                        break;
                    case "=":
                        //equals
                        if(commands.Length > 1)
                        {
                            if(commands[1] != "$")
                                currentValue = Convert.ToInt32(commands[1]);
                            else
                                currentValue = fileValue;
                        }
                        break;
                }

                if(currentValue < 0)
                    currentValue = 0;

                if(abort)
                {
                    Console.WriteLine("An error occurred at line " + i);
                    break;
                }

                Console.WriteLine(currentValue);

            }

            Console.WriteLine("Execution complete");

        }

    }
}
