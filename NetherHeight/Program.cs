var target = new List<byte> { 0x10, 0xA0, 0x52, 0xE0, 0x03, 0X13, 0xAA, 0xE1, 0x03, 0x15, 0xAA, 0xE2, 0x03, 0x16, 0xAA };
var bytes = File.ReadAllBytes("./libminecraftpe.so");
var start = DateTime.Now;
for (int k = 0; k < bytes.Length; k++)
{
    int match_times = 0;
    for (int j = 0; j < target.Count; j++)
    {
        if (bytes[k + j] != target[j])
        {
            break;
        }
        match_times++;
    }
    if (match_times == target.Count)
    {
        bytes[k] = 0x40;
        break;
    }
}
File.WriteAllBytes("./libminecraftpe.so", bytes);
var end = DateTime.Now;
Console.WriteLine("Patch sucess in {0} seconds", (end - start).TotalSeconds);
Console.Read();