export default function ({ store, redirect, route }) {

  const logado = store.getters['usuario/USER_LOGGED_IN']
  const routePath = route.path

  if (logado === false && routePath !== '/') {
    return redirect('/')
  } else if (logado === true && routePath === '/') {
    return redirect('/album/album')
  }
}
