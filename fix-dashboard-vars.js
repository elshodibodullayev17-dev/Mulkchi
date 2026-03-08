const fs = require('fs')
const base =
	'c:/Bitiruv malakaviy ishi/Mulkchi/mulkchi-frontend/src/app/pages/dashboard/'

const files = [
	'layout/dashboard-layout.component.scss',
	'overview/dashboard-overview.component.scss',
	'my-properties/my-properties.component.scss',
	'payments/payments.component.scss',
	'requests/requests.component.scss',
	'settings/settings.component.scss',
	'favorites/favorites.component.scss',
	'notifications/notifications.component.scss',
]

const replacements = [
	['var(--primary-dark)', 'var(--background)'],
	['var(--card-bg-2)', 'var(--card-alt)'],
	['var(--card-bg)', 'var(--card)'],
	['var(--border)', 'var(--border-color)'],
	['var(--text-muted)', 'var(--muted)'],
	['var(--text)', 'var(--foreground)'],
	['var(--gold)', 'var(--primary)'],
	['var(--green)', 'var(--success)'],
]

files.forEach(f => {
	const path = base + f
	if (!fs.existsSync(path)) {
		console.log('SKIP (not found):', f)
		return
	}
	let content = fs.readFileSync(path, 'utf8')
	let changed = 0
	replacements.forEach(([from, to]) => {
		const before = content
		content = content.split(from).join(to)
		if (content !== before) changed++
	})
	fs.writeFileSync(path, content)
	console.log(`${f}: ${changed} replacement types applied`)
})

// Also fix dashboard-layout: hardcoded dark background in gradient
const layoutPath = base + 'layout/dashboard-layout.component.scss'
let layout = fs.readFileSync(layoutPath, 'utf8')
layout = layout.replace(
	'background: linear-gradient(\n    180deg,\n    var(--card) 0%,\n    rgba(15, 15, 15, 0.98) 100%\n  );',
	'background: var(--sidebar-bg);',
)
layout = layout.replace(
	'background: linear-gradient(\n    180deg,\n    var(--card) 0%,\n    rgba(15, 15, 15, 0.98) 100%\n  );',
	'background: var(--sidebar-bg);',
)
fs.writeFileSync(layoutPath, layout)
console.log('Layout gradient fix: done')
