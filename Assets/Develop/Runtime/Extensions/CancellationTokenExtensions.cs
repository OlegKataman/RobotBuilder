using System.Threading;

namespace Develop.Runtime.Extensions
{
    public static class CancellationTokenSourceExtensions
    {
        public static void CancelAndDispose(this CancellationTokenSource self)
        {
            if (self == null) return;
    
            if (!self.IsCancellationRequested)
                self.Cancel();
    
            self.Dispose();
        }

        public static CancellationTokenSource Recreate(this CancellationTokenSource self)
        {
            self.CancelAndDispose();
            
            return new CancellationTokenSource();
        }
    }
}