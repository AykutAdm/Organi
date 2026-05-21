/* ============================================
   ORGANI ADMIN — Chart Interactions
   ============================================ */
document.addEventListener('DOMContentLoaded', () => {
  /* Period tab toggle */
  document.querySelectorAll('.period-tab').forEach(tab => {
    tab.addEventListener('click', function () {
      this.closest('.period-tabs')
          .querySelectorAll('.period-tab')
          .forEach(t => t.classList.remove('active'));
      this.classList.add('active');
    });
  });
});
