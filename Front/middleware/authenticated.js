export default function ({ store, redirect, route }) {
  console.log('usuario logado:')
  console.log(!store.getters['auth/USER_LOGGED_IN'])
  if (!store.getters['auth/USER_LOGGED_IN'] && route.path !== '/') {
    console.log('entrou no redirect')
    return redirect('/')
  }
}
