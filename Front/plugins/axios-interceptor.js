export default function ({ store, app, router }) {
  const { $axios } = app
  $axios.onRequest(async (req) => {
   console.log('resuisitando')
   store.commit('global/TOGGLE_LOADING', true)
   return req
  })

  $axios.onResponse((res) => {
    console.log('terminou')
    store.commit('global/TOGGLE_LOADING', false)
    return res
  })

  $axios.onError((err) => {
    console.log('erro')
    store.commit('global/TOGGLE_LOADING', false)
    console.log(err)
  })
}
