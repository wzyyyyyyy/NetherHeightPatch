var target = new byte[] { 0x10, 0xA0, 0x52, 0xE0, 0x03, 0X13, 0xAA, 0xE1, 0x03, 0x15, 0xAA, 0xE2, 0x03, 0x16, 0xAA };
var bytes = File.ReadAllBytes("./libminecraftpe.so");
var start = DateTime.Now;
for (int k = 0; k < bytes.Length; k++)
{
    int match_times = 0;
    for (int j = 0; j < target.Length; j++)
    {
        if (bytes[k + j] != target[j])
        {
            break;
        }
        match_times++;
    }
    if (match_times == target.Length)
    {
        Console.WriteLine("Find target");
        File.WriteAllBytes("./libminecraftpe.so.bak", bytes);
        bytes[k] = 0x40;
        File.WriteAllBytes("./libminecraftpe.so", bytes);
        var end = DateTime.Now;
        Console.WriteLine("Patch sucess in {0} seconds", (end - start).TotalSeconds);
        Console.Read();
        break;
    }
    k += match_times;
}
Console.WriteLine("Cannot find target");
Console.Read();