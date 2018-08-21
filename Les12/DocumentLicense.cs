using System;
using System.Collections.Generic;

namespace Les12
{
    public static class DocumentLicense
    {
        private static readonly List<string> ProKeys;
        private static readonly List<string> ExpKeys;
        static DocumentLicense()
        {
            ProKeys = new List<string> { "pro" };
            ExpKeys = new List<string> { "exp" };
        }
        public static DocumentWorker GetDocumentInstance(string s = "") =>
            ExpKeys.Contains(s) ? new ExpertDocumentWorker() : ProKeys.Contains(s) ? new ProDocumentWorker() : new DocumentWorker();
    }
    public class DocumentWorker
    {
        public void OpenDocument() => Console.WriteLine("Документ открыт");
        public virtual void EditDocument() => Console.WriteLine("Редактирование документа доступно в версии Про");
        public virtual void SaveDocument() => Console.WriteLine("Сохранение документа доступно в версии Про");
    }
    public class ProDocumentWorker : DocumentWorker
    {
        public override void EditDocument() => Console.WriteLine("Документ отредактирован");
        public override void SaveDocument() => Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Эксперт");
    }
    public class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void SaveDocument() => Console.WriteLine("Документ сохранен в новом формате");
    }
}

