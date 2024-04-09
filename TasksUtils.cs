using System;


{
	public TasksUtils()
	{
        public static void RunSync(Func<Task> fn)
        {
            var task = fn();
            task.GetAwaiter().GetResult();
        }

        public static T RunSync<T>(Func<Task<T>> fn)
        {
            var task = fn();
            return task.GetAwaiter().GetResult();
        }
    }

