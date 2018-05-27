using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace GuruComponents.Netrix.ComInterop
{
    /// <summary>
    /// IMoniker-Implementation for loading html into a document while having the ability to set the base url.
    /// </summary>
    /// <remarks>
    /// Borrowed from https://www.codeproject.com/Articles/18935/The-most-complete-C-Webbrowser-wrapper-control. 
    /// All the credits to mehrcpp!
    /// </remarks>
    public class LoadHtmlMoniker : IMoniker
    {
        static Guid IID_IStream = new Guid("0000000c-0000-0000-C000-000000000046");

        IntPtr streamPtr;
        IStream uStream;
        string baseUrl;

        /// <summary>
        /// Initializes the internal IStream-instance and stores the base url.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="baseUrl"></param>
        public void InitLoader(string content, string baseUrl)
        {
            this.baseUrl = baseUrl;

            string byteOrderMark;
            byte[] preamble = UnicodeEncoding.Unicode.GetPreamble();
            byteOrderMark = UnicodeEncoding.Unicode.GetString(preamble, 0, preamble.Length);
            long thesize = preamble.Length + UnicodeEncoding.Unicode.GetByteCount(content);
            streamPtr = Marshal.StringToHGlobalUni(String.Concat(byteOrderMark, content));
            Win32.CreateStreamOnHGlobal(streamPtr, true, out uStream);
            uStream.SetSize(thesize);
        }

        /// <summary>
        /// IMoniker.GetClassID is not implemented.
        /// </summary>
        /// <param name="pClassID"></param>
        public void GetClassID(out Guid pClassID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMoniker.IsDirty is not implemented.
        /// </summary>
        /// <returns></returns>
        public int IsDirty()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMoniker.Load is not implemented.
        /// </summary>
        /// <param name="pStm"></param>
        public void Load(IStream pStm)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMoniker.Save is not implemented.
        /// </summary>
        /// <param name="pStm"></param>
        /// <param name="fClearDirty"></param>
        public void Save(IStream pStm, bool fClearDirty)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMoniker.GetSizeMax is not implemented.
        /// </summary>
        /// <param name="pcbSize"></param>
        public void GetSizeMax(out long pcbSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMoniker.BindToObject is not implemented.
        /// </summary>
        /// <param name="pbc"></param>
        /// <param name="pmkToLeft"></param>
        /// <param name="riidResult"></param>
        /// <param name="ppvResult"></param>
        public void BindToObject(IBindCtx pbc, IMoniker pmkToLeft, ref Guid riidResult, out object ppvResult)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implements IMoniker.BindToStorage. Passes a ref to the internal stream that holds the page data to load.
        /// </summary>
        /// <param name="pbc"></param>
        /// <param name="pmkToLeft"></param>
        /// <param name="riid"></param>
        /// <param name="ppvObj"></param>
        public void BindToStorage(IBindCtx pbc, IMoniker pmkToLeft, ref Guid riid, out object ppvObj)
        {
            ppvObj = null;
            if (riid.Equals(IID_IStream))
                ppvObj = (IStream)uStream;
        }

        /// <summary>
        /// IMoniker.Reduce is not implemented.
        /// </summary>
        /// <param name="pbc"></param>
        /// <param name="dwReduceHowFar"></param>
        /// <param name="ppmkToLeft"></param>
        /// <param name="ppmkReduced"></param>
        public void Reduce(IBindCtx pbc, int dwReduceHowFar, ref IMoniker ppmkToLeft, out IMoniker ppmkReduced)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMoniker.ComposeWith is not implemented.
        /// </summary>
        /// <param name="pmkRight"></param>
        /// <param name="fOnlyIfNotGeneric"></param>
        /// <param name="ppmkComposite"></param>
        public void ComposeWith(IMoniker pmkRight, bool fOnlyIfNotGeneric, out IMoniker ppmkComposite)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMoniker.Enum is not implemented.
        /// </summary>
        /// <param name="fForward"></param>
        /// <param name="ppenumMoniker"></param>
        public void Enum(bool fForward, out IEnumMoniker ppenumMoniker)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMoniker.IsEqual is not implemented.
        /// </summary>
        /// <param name="pmkOtherMoniker"></param>
        /// <returns></returns>
        public int IsEqual(IMoniker pmkOtherMoniker)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMoniker.Hash is not implemented.
        /// </summary>
        /// <param name="pdwHash"></param>
        public void Hash(out int pdwHash)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMoniker.IsRunning is not implemented.
        /// </summary>
        /// <param name="pbc"></param>
        /// <param name="pmkToLeft"></param>
        /// <param name="pmkNewlyRunning"></param>
        /// <returns></returns>
        public int IsRunning(IBindCtx pbc, IMoniker pmkToLeft, IMoniker pmkNewlyRunning)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMoniker.GetTimeOfLastChange is not implemented.
        /// </summary>
        /// <param name="pbc"></param>
        /// <param name="pmkToLeft"></param>
        /// <param name="pFileTime"></param>
        public void GetTimeOfLastChange(IBindCtx pbc, IMoniker pmkToLeft, out System.Runtime.InteropServices.ComTypes.FILETIME pFileTime)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMoniker.Inverse is not implemented.
        /// </summary>
        /// <param name="ppmk"></param>
        public void Inverse(out IMoniker ppmk)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMoniker.CommonPrefixWith is not implemented.
        /// </summary>
        /// <param name="pmkOther"></param>
        /// <param name="ppmkPrefix"></param>
        public void CommonPrefixWith(IMoniker pmkOther, out IMoniker ppmkPrefix)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMoniker.RelativePathTo is not implemented.
        /// </summary>
        /// <param name="pmkOther"></param>
        /// <param name="ppmkRelPath"></param>
        public void RelativePathTo(IMoniker pmkOther, out IMoniker ppmkRelPath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implements IMoniker.GetDisplayName to return the base url.
        /// </summary>
        /// <param name="pbc"></param>
        /// <param name="pmkToLeft"></param>
        /// <param name="ppszDisplayName"></param>
        public void GetDisplayName(IBindCtx pbc, IMoniker pmkToLeft, out string ppszDisplayName)
        {
            ppszDisplayName = baseUrl;
        }

        /// <summary>
        /// IMoniker.ParseDisplayName is not implemented.
        /// </summary>
        /// <param name="pbc"></param>
        /// <param name="pmkToLeft"></param>
        /// <param name="pszDisplayName"></param>
        /// <param name="pchEaten"></param>
        /// <param name="ppmkOut"></param>
        public void ParseDisplayName(IBindCtx pbc, IMoniker pmkToLeft, string pszDisplayName, out int pchEaten, out IMoniker ppmkOut)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMoniker.IsSystemMoniker is not implemented.
        /// </summary>
        /// <param name="pdwMksys"></param>
        /// <returns></returns>
        public int IsSystemMoniker(out int pdwMksys)
        {
            throw new NotImplementedException();
        }
    }
}
