using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace EyeClops.DataLayer.DeSerializer
{
    public static class BinaryDeSerializer
    {
        private const string DataSeparator = ",,,,,,,";
        private const char DataReplacement = '.';

        public static void WriteBinaryFile(List<byte[][]> binaryInput, string storePath, string fileName,
            string fileAppendix)
        {
//            List<string> combinedBineryLines = new List<string>();

//            foreach (string[] lineGroup in binaryInput)
//            {
//                string[] replacedStrings = new string[lineGroup.Length];
//                for (int i = 0; i < lineGroup.Length; i++)
//                {
//                    if (lineGroup[i] != null)
//                        replacedStrings[i] = lineGroup[i].Replace(DataSeparator, DataReplacement);
//                    else
//                        replacedStrings[i] = lineGroup[i];
//                }
//
//                combinedBineryLines.Add(String.Join(DataSeparator.ToString(), replacedStrings));
//            }
            Debug.LogFormat("###Hier im schreib prozess {0}", storePath);
            try
            {
                if (!Directory.Exists(storePath))
                    Directory.CreateDirectory(storePath);

                using (FileStream fileStream =
                    new FileStream(storePath + fileName + fileAppendix,
                        FileMode.Create))
                {
                    using (BinaryWriter binaryWriter =
                        new BinaryWriter(fileStream))
                    {
                        foreach (byte[][] binLine in binaryInput)
                        {
                            foreach (byte[] bytese in binLine)
                            {
                                foreach (byte b in bytese)
                                {
                                    binaryWriter.Write(b);
                                }

                                binaryWriter.Write(DataSeparator);
                            }

                            binaryWriter.Write(System.Environment.NewLine);
                        }

                        binaryWriter.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }


        public static void ReadBinaryFile(string filePath, ref List<byte[][]> binaryReadedFile)
        {
//            byte[] readAllBytes = File.ReadAllBytes(filePath);
//            foreach (byte readAllByte in readAllBytes)
//            {
//                Debug.Log("ReadAllBytes: " + readAllByte);
//            }

            try
            {
                var file = new StreamReader(filePath); // big string
                var readToEnd = file.ReadToEnd();
                var lines = readToEnd.Split(new char[] {'\n'}); // big array
                var count = lines.Length;

                file.Close();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
//                readToEnd

//                    using (var streamRead = new StreamReader(fileStream))
                    using (var streamRead = new BinaryReader(fileStream))
                    {
//                        while (!streamRead.EndOfStream)
                        while (streamRead.BaseStream.Position != streamRead.BaseStream.Length)
                        {
                            int index = 0;
//                            streamRead.ReadLine()
//                            byte[] readBytes = streamRead.ReadBytes();
                            Debug.Log("The StreamRead: " + streamRead.Read());
//                            string s = BitConverter.ToString(streamRead.ReadByte());
                            Debug.Log("Before String: " +
                                      BitConverter.ToString(Encoding.ASCII.GetBytes(DataSeparator)));
//                            Debug.Log("Try out a String: " + s);
                            byte[] readBytes = streamRead.ReadBytes(streamRead.Read());
                            int i = 0;
                            binaryReadedFile.Add(FindSingleDates(readBytes));
//                            foreach (byte readByte in readBytes)
//                            {
//                                Debug.Log(i + " Hier sind jetzt Bytes ähnlich " +
//                                          readByte.Equals(BitConverter.GetBytes(DataSeparator)[1]) + " : " +
//                                          readByte+ " : " +
//                                          BitConverter.GetBytes(DataSeparator)[1] + " : " + BitConverter.GetBytes(DataSeparator).Length);
//                                i++;
//                            }

                            Debug.LogFormat("Now the ReadByte: " + BitConverter.ToString(readBytes));
//                            Debug.LogFormat(BitConverter.ToString(readByte));
//                            string readLine = streamRead.ReadLine();
//                            string[] strings = readLine.Split(DataSeparator);
//                            byte[][] test = new byte[strings.Length][];
//                            foreach (var s in strings)
//                            {
//                                byte[] bytes = Encoding.ASCII.GetBytes(s);
//                                test[index] = bytes;
//                                index++;
//                                foreach (byte b in bytes)
//                                {
////                                    Debug.LogFormat("Hallo hier sind strings: {0}", b);
//                                }
//                            }

//                            Debug.Log("Index: " + index + " : " + count);

//                            BitConverter.GetBytes(strings);
//                            binaryReadedFile.Add(strings);
//                            binaryReadedFile.Add(test);
                        }
                    }

/*

                    using (BinaryReader binReader = new BinaryReader(fileStream))
                    {
                        while (binReader.BaseStream.Position != binReader.BaseStream.Length)
                        {
                            byte[] readBytes = binReader.ReadBytes(Convert.ToInt32(binReader.BaseStream.Position));
//                            readBytes
//                            binReader.
//binReader.Read(fileStream.)
                            byte[] bin = binReader.ReadBytes(Convert.ToInt32(fileStream.Length));
                            foreach (byte b in bin)
                            {
//                                Debug.Log("Hier ist jeder Byte: " + b);
                            }

//                            var readLine = Encoding.UTF8.GetString(bin);
//                            string[] split = readLine.Split(new[] {Environment.NewLine},
//                                StringSplitOptions.None);
//                            foreach (string singleLine in split)
//                            {
//                                binaryReadedFile.Add(singleLine.Split(DataSeparator));
//                            }
                        }
                    }*/
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }

        private static byte[][] FindSingleDates(byte[] readBytes)
        {
            int currentCount = 0;
            int dateNumber = 0;

//            byte[] remarkByte = new byte[100];
            List<byte[]> helperByteArrayList = new List<byte[]>();
            List<byte> reamarkByte = new List<byte>();
            List<byte> flushBytes = new List<byte>();
            foreach (byte readByte in readBytes)
            {
                //Hier müsste ich mir merken welche Bytes mir noch fehlen
                if (currentCount < Encoding.ASCII.GetBytes(DataSeparator).Length &&
                    readByte.Equals(Encoding.ASCII.GetBytes(DataSeparator)[currentCount]))
                {
                    reamarkByte.Add(readByte);
                    currentCount++;
                }
                else
                {
                    //Es müsste so lange diese Liste gefüllt werden, bis ich in den DataSeparator rein laufe und es wirklich ein DataSeparator war, dann muss ich anschließend die Daten da hinzufügen

                    if (reamarkByte.Count > 0)
                    {
                        foreach (byte b in reamarkByte)
                            flushBytes.Add(b);
                        flushBytes = new List<byte>();
                    }
                    if (currentCount != 0)
                    {
                        flushBytes.Add(readByte);
                        dateNumber++;
                    }

                    currentCount = 0;
                }

                if (currentCount == Encoding.ASCII.GetBytes(DataSeparator).Length)
                {
                    //reset Counting
                    reamarkByte = new List<byte>();
                    var helperArray = new byte[flushBytes.Count];
                    for (int i = 0; i < flushBytes.Count; i++)
                    {
                        helperArray[i] = flushBytes[i];
                    }

                    helperByteArrayList.Add(helperArray);
                    flushBytes = new List<byte>();
                    //Add the values!
                }
            }

            //This would remap the bytes from the list
            var returnBytes = new byte[helperByteArrayList.Count][];
            for (int i = 0; i < helperByteArrayList.Count; i++)
            {
                returnBytes[i] = helperByteArrayList[i];
            }

            Debug.LogFormat("Hier sind die Anzahl an Dateien teiler gefunden wurden: {0} ", dateNumber);
            return returnBytes;
        }
    }
}