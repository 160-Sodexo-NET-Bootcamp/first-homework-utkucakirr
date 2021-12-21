using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtkuCakir_Odev1_BookApi.Controllers
{
    public class Book
    {
        public int Id { get; set; }
        public int SeriNo { get; set; }
        public string KitapAdi { get; set; }
        public string Yazar { get; set; }
        public int SayfaSayisi { get; set; }
    }

    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public List<Book> Books;

        public BookController()
        {
            //Kitap Listesine kayıtlar eklendi.
            Books = new List<Book>();
            Books.Add(new Book { Id = 1, KitapAdi = "Kitap1", SayfaSayisi = 300, SeriNo = 123, Yazar = "Yazar1"});
            Books.Add(new Book { Id = 2, KitapAdi = "Kitap2", SayfaSayisi = 123, SeriNo = 124, Yazar = "Yazar2" });
            Books.Add(new Book { Id = 3, KitapAdi = "Kitap3", SayfaSayisi = 413, SeriNo = 126, Yazar = "Yazar3" });
            Books.Add(new Book { Id = 4, KitapAdi = "Kitap4", SayfaSayisi = 234, SeriNo = 130, Yazar = "Yazar4" });
            Books.Add(new Book { Id = 5, KitapAdi = "Kitap5", SayfaSayisi = 100, SeriNo = 141, Yazar = "Yazar5" });
            Books.Add(new Book { Id = 6, KitapAdi = "Kitap6", SayfaSayisi = 255, SeriNo = 125, Yazar = "Yazar6" });
        }

        //Listedeki tüm kitapları listeleme
        [HttpPost]
        public IActionResult GetAll()
        {
            return Ok(Books);
        }

        //FromQuery kullanarak kitap detayları sorgulama
        [HttpGet]
        public IActionResult GetById([FromQuery] int id)
        {
            var book = Books.Where(x => x.Id == id).FirstOrDefault();
            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        //FromRoute kullanarak kitap detayları sorgulama
        [HttpGet("{id}")]
        public IActionResult GetById2([FromRoute] int id)
        {
            var book = Books.Where(x => x.Id == id).FirstOrDefault();
            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        //Listeye kitap ekleme
        [HttpPost("add")]
        public IActionResult Add([FromBody] Book book)
        {
            Books.Add(book);
            return Ok(Books);
        }

        //Listede bulunan bir kitabı güncelleme
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id, Book book)
        {
            var temp = Books.Where(x => x.Id == id).FirstOrDefault();
            if (temp == null)
            {
                return NotFound();
            }

            temp.KitapAdi = book.KitapAdi;
            temp.SayfaSayisi = book.SayfaSayisi;
            temp.SeriNo = book.SeriNo;
            temp.Yazar = book.Yazar;
            return Ok(Books);
        }

        //Listede bulunan bir kitabı silme
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var temp = Books.Where(x => x.Id == id).FirstOrDefault();
            if (temp == null)
            {
                return Ok("Not Found");
            }

            Books.Remove(temp);
            return Ok(Books);
        }
    }
}
