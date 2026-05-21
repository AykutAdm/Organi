/* ============================================
   ORGANI ADMIN — Search (Table Filter)
   ============================================ */
document.addEventListener('DOMContentLoaded', () => {
  const searchBox = document.querySelector('.search-box');
  if (!searchBox) return;

  searchBox.addEventListener('click', () => {
    const term = prompt('Search products, categories...');
    if (!term) return;
    document.querySelectorAll('tbody tr').forEach(row => {
      const text = row.textContent.toLowerCase();
      row.style.display = text.includes(term.toLowerCase()) ? '' : 'none';
    });
  });
});
