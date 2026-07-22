using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare_of_the_Window
{
    internal class Sounds
    {
        public static void Sound1()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)((t | (t >> 9 | t >> 7)) * t & (t >> 11 | t >> 9)));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound2()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)((t << (t & t >> 11)) + (t >> 11)));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound3()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)(10 * (t >> 7 | 3 * t | t >> (t >> 15)) + (t >> 8 & 5)));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound4()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)(((t << (t & t >> 8)) * 2 + (t | t >> 9 | t >> 7))));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound5()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)((t >> 7 | t | t >> 6) * 10 + 4 * (t & t >> 13 | t >> 6)));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound6()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)((t >> (t & t >> 11)) * 2));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound7()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)((t >> 5) | (t << 4) | ((t & 1023) ^ 1981) | ((t - 67) >> 4)));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound8()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)((t >> 4) * (t >> 2) | t >> (t >> 12) % 4));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound9()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)((t >> 2) * (t & ((t & 32768) != 0 ? 16 : 24) | t >> (t >> 8 & 24)) | t >> 3));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound10()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)((1 + (t >> 10) % 7) * (t * (1 + (t >> 13) % 4) % (24 + 9 * (t >> 14) % 8) & 16) * 10));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound11()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)(t * (((t & 4096) != 0 ? t % 65536 < 59392 ? 7 : t & 7 : 16) + (1 & t >> 14)) >> (3 & -t >> ((t & 2048) != 0 ? 2 : 10)) | t >> ((t & 16384) != 0 ? (t & 4096) != 0 ? 10 : 3 : 2)));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound12()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)(100 * ((t << 2 | t >> 5 | t ^ 63) & (t << 10 | t >> 11))));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound13()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)((t & t >> 12) * (t >> 4 | t >> 8)));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound14()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)(t * (((t & 4096)  != 0 ? 6 : 16) + (1 & t >> 14)) >> (3 & t >> 8) | t >> ((t & 4096) != 0 ? 3 : 4)));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound15()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)(t >> 6 ^ t & 0x25 | t + (t ^ t >> 11) - t * (((t % 24) != 0 ? 2 : 6) & t >> 11) ^ t << 1 & ((t & 0x256) != 0 ? t >> 4 : t >> 10)));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound16()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)((t * t / (1 + (t >> 9 & t >> 8))) & 128));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound17()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                {
                    int a = (t >> 13 ^ t >> 8);
                    data[t] = (byte)(a == 0 ? 0 : (t * t) / a);
                }

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
        public static void Sound18()
        {
            using (var soundstream1 = new MemoryStream())
            {
                var soundwriter1 = new BinaryWriter(soundstream1);

                soundwriter1.Write("RIFF".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)0);             // chunk size
                soundwriter1.Write("WAVE".ToCharArray());  // format

                soundwriter1.Write("fmt ".ToCharArray());  // chunk id
                soundwriter1.Write((UInt32)16);            // chunk size
                soundwriter1.Write((UInt16)1);             // audio format

                var channels = 1;
                var sample_rate = 8000;
                var bits_per_sample = 8;

                soundwriter1.Write((UInt16)channels);
                soundwriter1.Write((UInt32)sample_rate);
                soundwriter1.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                soundwriter1.Write((UInt16)(channels * bits_per_sample / 8));               // block align

                soundwriter1.Write((UInt16)bits_per_sample);

                soundwriter1.Write("data".ToCharArray());

                var seconds = 20;

                var data = new byte[sample_rate * seconds];

                for (int t = 0; t < data.Length; t++)
                    data[t] =
((byte)(t + (t & t ^ t >> 6) - t * ((t >> 9) & (t % 16 != 0 ? 2 : 6) & t >> 9)));

                soundwriter1.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) soundwriter1.Write(elt);

                soundwriter1.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                soundwriter1.Write((UInt32)(soundwriter1.BaseStream.Length - 8)); // chunk size

                soundstream1.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(soundstream1).PlaySync();

                {
                    return;
                }
            }
        }
    }
}
