// typeAlign = -7;
// byOfMemoryAlign = -5;
// typeMinAlign = 30;
// typeMaxAlign = 30; 

string topics       = String.Format("{0,-7} {1,-5} {2,18} {3,30}",  "Type",         "Byte(s) of memory",    "Min",              "Max");
string sbyt         = String.Format("{0,-7} {1,-5} {2,30} {3,30}",  nameof(SByte),  sizeof(sbyte),          SByte.MinValue,     SByte.MaxValue);
string byt          = String.Format("{0,-7} {1,-5} {2,30} {3,30}",  nameof(Byte),   sizeof(sbyte),          Byte.MinValue,      Byte.MaxValue);
string shor         = String.Format("{0,-7} {1,-5} {2,30} {3,30}",  nameof(Int16),  sizeof(short),          short.MinValue,     short.MaxValue);
string int32        = String.Format("{0,-7} {1,-5} {2,30} {3,30}",  nameof(Int32),  sizeof(int),            int.MinValue,       int.MaxValue);
string Uint32       = String.Format("{0,-7} {1,-5} {2,30} {3,30}",  nameof(UInt32), sizeof(uint),           uint.MinValue,      uint.MaxValue);
string LONG         = String.Format("{0,-7} {1,-5} {2,30} {3,30}",  nameof(Int64),  sizeof(long),           long.MinValue,      long.MaxValue);
string ULONG        = String.Format("{0,-7} {1,-5} {2,30} {3,30}",  nameof(UInt64), sizeof(ulong),          ulong.MinValue,     ulong.MaxValue);
string FLOAT        = String.Format("{0,-7} {1,-5} {2,30} {3,30}",  nameof(Single), sizeof(float),          float.MinValue,     float.MaxValue);
string DOUBLE       = String.Format("{0,-7} {1,-5} {2,30} {3,30}",  nameof(Double), sizeof(double),         double.MinValue,    double.MaxValue);
string DECIMAL      = String.Format("{0,-7} {1,-5} {2,18} {3,30}",  nameof(Decimal),sizeof(decimal),        decimal.MinValue,   decimal.MaxValue);

string [] dataTypes = {sbyt,byt,shor,int32,Uint32,LONG,ULONG,FLOAT,DOUBLE,DECIMAL};
Console.WriteLine("---------------------------------------------------------------------------");
Console.WriteLine(topics);
Console.WriteLine("---------------------------------------------------------------------------");
Console.WriteLine(string.Join("\n",dataTypes));
Console.WriteLine("---------------------------------------------------------------------------");
