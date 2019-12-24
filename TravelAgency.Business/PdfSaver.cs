using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Business.Tours;
using TravelAgency.DataAccessLayer.Entities;

namespace TravelAgency.Business
{
    public static class PdfSaver
    {
        public static string SaveOrder(IEnumerable<Order> orders, string path, string fileName)
        {
            string fullPath = Path.Combine(path, fileName);
            using (var doc = new Document(PageSize.A4))
            {
                var pdfWriter = PdfWriter.GetInstance(doc, new FileStream(fullPath, FileMode.Create));

                string arial = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");
                var baseFont = BaseFont.CreateFont(arial, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                var font = new Font(baseFont, 14F, Font.NORMAL);

                doc.Open();
                if (!orders.Any())
                {
                    doc.Add(new Phrase("Нет заказов за текущую дату", font));
                    return fullPath;
                }

                foreach (var order in orders)
                    doc.Add(new Phrase(CreateOrderTemlate(order), font));

                return fullPath;
            }
        }

        private static string CreateOrderTemlate(Order order)
        {
            string template = $"Заказ №{order.Id}\nТур: {order.Tour.Name}\n" +
                $"Цена с учетом скидки: {TourPriceSetter.SetPriceWithSale(order.Tour).Price} грн\n" +
                $"Покупатель: {order.FirstName} {order.LastName}\n" +
                $"Номер телефона: {order.PhoneNumber}\n\n";

            return template;
        }
    }
}
