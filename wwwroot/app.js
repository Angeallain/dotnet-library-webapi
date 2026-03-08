async function loadBooks() {
  const res   = await fetch('/api/book');
  const books = await res.json();
  const list  = document.getElementById('booksList');
  const empty = document.getElementById('emptyMsg');

  list.innerHTML = '';

  if (books.length === 0) {
    empty.style.display = 'block';
    return;
  }

  empty.style.display = 'none';

  books.forEach(b => {
    const li = document.createElement('li');
    li.innerHTML = `
      <div class="book-info">
        <strong>${b.title}</strong>
        <span>${b.author}</span>
      </div>
      <div class="book-right">
        <span class="badge ${b.isBorrowed ? 'borrowed' : 'available'}">
          ${b.isBorrowed ? 'Emprunté' : 'Disponible'}
        </span>
        ${!b.isBorrowed
          ? `<button class="borrow-btn" onclick="borrowBook(${b.id})">Emprunter</button>`
          : ''}
      </div>`;
    list.appendChild(li);
  });
}

async function addBook() {
  const title  = document.getElementById('title').value.trim();
  const author = document.getElementById('author').value.trim();
  if (!title || !author) return alert("Remplis les deux champs !");

  await fetch('/api/book', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ title, author })
  });

  document.getElementById('title').value  = '';
  document.getElementById('author').value = '';
  loadBooks();
}

async function borrowBook(id) {
  await fetch(`/api/book/${id}/borrow`, { method: 'PUT' });
  loadBooks();
}

loadBooks();
