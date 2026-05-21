/* ============================================
   ORGANI ADMIN — Sidebar Navigation
   ============================================ */
document.addEventListener('DOMContentLoaded', () => {
  const navItems = document.querySelectorAll('.nav-item');
  const path = window.location.pathname.toLowerCase();

  navItems.forEach(item => {
    const href = item.getAttribute('href');
    if (!href || href === '#' || href === '#!') return;

    const target = href.toLowerCase();
    const isActive = path === target || path.startsWith(target + '/');
    item.classList.toggle('active', isActive);
  });
});
