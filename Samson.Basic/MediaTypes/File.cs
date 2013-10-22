using Samson.MediaTypes;

namespace Samson.Basic.MediaTypes
{
    /// <summary>
    ///     A basic file in the media section.
    /// </summary>
    public class File : Downloadable, IFile
    {
        public File(int id)
            : base(id)
        {
        }
    }
}