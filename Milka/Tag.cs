using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milka
{
    public class Tag
    {
        private int _header;
        private byte _partition;

        public int Header
        {
            get { return _header; }
            set
            {
                if (value != 48) IsValid = false;
                else _header = value;
            }
        }

        public byte Filter { get; set; }
        public byte Partition
        {
            get { return _partition; }
            set
            {
                if (value == 7) IsValid = false;
                else _partition = value;
            }
        }
        public long Prefix { get; set; }
        public int Reference { get; set; }
        public long Serial { get; set; }
        public bool IsValid { get; set; } = true;

        public Tag(string hexTag)
        {
            string binaryTag = ConvertToBinary(hexTag);
            if (binaryTag == "") IsValid = false;
            else
            {
                Header = Convert.ToInt32(binaryTag.Substring(0, 8), 2);
                Filter = Convert.ToByte(binaryTag.Substring(8, 3), 2);
                Partition = Convert.ToByte(binaryTag.Substring(11, 3), 2);
                int partitionBits = Constants.partitionValue[Partition];
                Prefix = Convert.ToInt64(binaryTag.Substring(14, partitionBits), 2);
                Reference = Convert.ToInt32(binaryTag.Substring(14 + partitionBits, 44 - partitionBits), 2);
                Serial = Convert.ToInt64(binaryTag.Substring(58, 38), 2);
            }
        }

        private string ConvertToBinary(string hexTag)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in hexTag)
            {
                if (c >= '0' && c <= 'F')
                    sb.Append(Constants.hexBin[c]);
                else return "";
            }
            return sb.ToString();
        }
    }
}
