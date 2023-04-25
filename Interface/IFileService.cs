using System.Collections.Generic;

namespace WorkMVVM
{
    public interface IFileService
    {
        List<T> Open<T>(string filename);
        void Save<T>(string filename, List<T> list);
    }
}
