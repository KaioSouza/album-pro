export default function ({ store, app, router }) {
  const { $axios } = app
  $axios.onRequest(async (req) => {
   store.commit('global/TOGGLE_LOADING', true)
   return req
  })

  $axios.onResponse((res) => {
    store.commit('global/TOGGLE_LOADING', false)
    return res
  })

  $axios.onError((err) => {
    store.commit('global/TOGGLE_LOADING', false)
  })
}
