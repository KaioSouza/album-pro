export const state = () => ({
  user: null
})

export const mutations = {

  SET_USER (state, user) {
    console.log('entrou no ser user')
    state.user = user
    console.log(state.user)
    console.log(user)
  }
}

export const actions = {

  async SET_USER_APP ({ commit }, payload) {
    await commit('SET_USER', payload)
  },

  async LOGIN ({ commit }, payload) {
    try {
      const data = await this.$axios.$post('http://localhost:57987/usuario', payload)

      if (data) {
        console.log(data)
        commit('SET_USER', {
          nomeUsuario: data.userName,
          nomeCompleto: data.nome,
          perfilAcesso: data.perfil,
          email: data.email,
        })
        console.log(state.user)
      }

      return !!data
    } catch (error) {
    }
  },
  async CADASTRAR ({ commit }, payload) {
    try {
      const data = await this.$axios.$post('http://localhost:57987/usuario/cadastrar', payload)

      if (data) {
        commit('SET_USER',data)
        return true
      }
    } catch (error) {
    }
  }
}

export const getters = {
  USER_LOGGED_IN: (state, getters) => {
    console.log('entrou no user Loged in?')
    console.log(!!state.user)
    return !!state.user
  },
  GET_USER: (state, getters) => {
    return state.user
  }
}
