namespace BlazorApp.Scheduler
{
    public class MoveFilesScheduler
    {
        public void Execute()
        {
            var source = @"C:\Scheduler\Source";
            var destination = @"C:\Scheduler\Destination";

            if (!Directory.Exists(source)) Directory.CreateDirectory(source);
            if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);

            var items = Directory.GetFiles(source, "*.*", SearchOption.AllDirectories).ToList();
            foreach (var item in items)
            {
                File.Move(item, Path.Combine(destination, Path.GetFileName(item)), true);
            }
        }
    }
}
