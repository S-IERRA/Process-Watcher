# Process-Watcher

A basic process watcher, 

usage: 

```cs
 public class Watcher
    {
        private ProcessWatcher Watcher = new();
        
        public static bool AutoFindToggle { get; set; }
        
        public void AutoFind()
        {
            if (!AutoFindToggle)
                return;

            Task.Factory.StartNew(() =>
            {
                Watcher.Created += process
                    => Find();

                Watcher.Auto();
            });
        }
        
        public void Find()
        {
            if (!AutoFindToggle && !Watcher.GetProcess())
            {
                Console.WriteLine("Please launch the application first!");
                return;
            }

            Process application = Watcher.Process;
        }
```
