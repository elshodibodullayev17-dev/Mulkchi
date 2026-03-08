const fs = require('fs')

const baseFront = 'c:/Bitiruv malakaviy ishi/Mulkchi/mulkchi-frontend/src/app/'

// ─── 1. Auth SCSS: replace old vars with semantic ones ───────────────────────
const varMap = [
	['var(--primary-dark)', 'var(--background)'],
	['var(--card-bg-2)', 'var(--card-alt)'],
	['var(--card-bg)', 'var(--card)'],
	// guard: replace --border) but not --border-color)
	[/var\(--border\)/g, 'var(--border-color)'],
	['var(--text-muted)', 'var(--muted)'],
	// guard: replace --text) but not --text-muted)
	[/var\(--text\)/g, 'var(--foreground)'],
	['var(--gold)', 'var(--primary)'],
	['var(--green)', 'var(--success)'],
	['var(--red)', 'var(--danger)'],
]

function applyVarMap(content) {
	varMap.forEach(([from, to]) => {
		if (from instanceof RegExp) {
			content = content.replace(from, to)
		} else {
			content = content.split(from).join(to)
		}
	})
	return content
}

;[
	'pages/auth/login/login.component.scss',
	'pages/auth/register/register.component.scss',
].forEach(f => {
	const path = baseFront + f
	let c = fs.readFileSync(path, 'utf8')
	const before = c
	c = applyVarMap(c)
	fs.writeFileSync(path, c)
	console.log(f.split('/').pop() + ':', c !== before ? 'updated' : 'no change')
})

// ─── 2. Favorites SCSS ────────────────────────────────────────────────────────
const favScss = `.favorites-page {
  padding: 28px;
}

.page-header h1 {
  font-family: 'Playfair Display', serif;
  font-size: 1.6rem;
  color: var(--foreground);
  margin-bottom: 24px;
}

.favorites-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
  gap: 24px;
}

.favorite-item {
  display: flex;
  flex-direction: column;
  gap: 8px;
}

.btn-remove {
  background: rgba(224, 82, 82, 0.08);
  border: 1px solid rgba(224, 82, 82, 0.25);
  color: var(--danger);
  padding: 8px 14px;
  border-radius: 8px;
  cursor: pointer;
  font-size: 13px;
  font-family: 'DM Sans', sans-serif;
  transition: background 0.2s;

  &:hover {
    background: rgba(224, 82, 82, 0.18);
  }
}

.empty-state {
  text-align: center;
  padding: 64px 24px;
  color: var(--muted);

  p {
    margin-bottom: 20px;
    font-size: 16px;
  }
}
`
fs.writeFileSync(
	baseFront + 'pages/dashboard/favorites/favorites.component.scss',
	favScss,
)
console.log('favorites.component.scss: rewritten')

// ─── 3. Notifications SCSS ────────────────────────────────────────────────────
const notifScss = `.notifications-page {
  padding: 28px;
}

.page-header h1 {
  font-family: 'Playfair Display', serif;
  font-size: 1.6rem;
  color: var(--foreground);
  margin-bottom: 24px;
}

.notifications-list {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.notification-card {
  display: flex;
  gap: 16px;
  background: var(--card);
  border: 1px solid var(--border-color);
  border-radius: 12px;
  padding: 16px 20px;
  transition: background 0.2s;

  &.unread {
    background: rgba(201, 168, 76, 0.05);
    border-color: rgba(201, 168, 76, 0.2);
  }

  &:hover {
    background: var(--muted-bg);
  }
}

.notif-icon {
  font-size: 22px;
  flex-shrink: 0;
  margin-top: 2px;
}

.notif-body {
  flex: 1;
  min-width: 0;
}

.notif-header {
  display: flex;
  align-items: center;
  gap: 8px;
  margin-bottom: 4px;
}

.notif-title {
  font-weight: 600;
  color: var(--foreground);
  font-size: 14px;
}

.unread-dot {
  width: 8px;
  height: 8px;
  border-radius: 50%;
  background: var(--primary);
  flex-shrink: 0;
}

.notif-text {
  color: var(--muted);
  font-size: 13px;
  margin: 0 0 6px;
  line-height: 1.5;
}

.notif-date {
  font-size: 11px;
  color: var(--muted);
  opacity: 0.7;
}

.empty-state {
  text-align: center;
  padding: 64px 24px;
  color: var(--muted);
  font-size: 15px;
}

.pagination {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 16px;
  margin-top: 32px;
  color: var(--muted);
  font-size: 14px;
}

.page-btn {
  background: var(--card);
  border: 1px solid var(--border-color);
  color: var(--foreground);
  width: 36px;
  height: 36px;
  border-radius: 8px;
  cursor: pointer;
  font-size: 16px;
  transition: all 0.15s;
  display: flex;
  align-items: center;
  justify-content: center;

  &:hover:not(:disabled) {
    border-color: var(--primary);
    color: var(--primary);
  }

  &:disabled {
    opacity: 0.3;
    cursor: not-allowed;
  }
}
`
fs.writeFileSync(
	baseFront + 'pages/dashboard/notifications/notifications.component.scss',
	notifScss,
)
console.log('notifications.component.scss: rewritten')

console.log('All SCSS fixes done!')
