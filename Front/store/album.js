export const state = () => ({
  albuns: [],
  album: null
})

export const mutations = {

  SET_ALBUNS (state, data) {
    state.albuns = data
  },

  SET_ALBUM (state, data) {
    state.album = data
  },
  DELETE_ALBUM (state, id) {
    state.albuns.splice(state.albuns.findIndex(x => x.id === id), 1)
  },
  PUT_ALBUM (state, payload) {
    console.log('entrou no put album')
    console.log(payload)
    state.album = payload
  },
  PUT_ALBUNS (state, payload) {

    console.log('teste')
    const album = state.albuns[state.albuns.findIndex(x => x.id === payload.id)]
    album.nome = payload.nome
    state.albuns.splice(state.albuns.findIndex(x => x.id === payload.id), 1)
    state.albuns.push(album)
    state.albuns = state.albuns.sort((a, b) => a.totalJaAdicionados - b.totalJaAdicionados)
    console.log(state.albuns)
  },
  DELETE_FOTO (state, payload) {
    state.album.fotos.splice(state.album.fotos.findIndex(x => x.id === payload.id), 1)
  },
  POST_ALBUM (state, payload) {
    state.albuns.push(payload)
  },
  PUT_FOTO (state, payload) {
    console.log('mutation')
    const foto = state.album.fotos[state.album.fotos.findIndex(x => x.id === payload.id)]

    foto.nome = payload.nome

    state.album.fotos.splice(state.album.fotos.findIndex(x => x.id === payload.id), 1)

    state.album.fotos.push(foto)

    state.album.fotos = state.album.fotos.sort((a, b) => a.totalJaAdicionados - b.totalJaAdicionados)

    console.log(state.album.fotos)
  }
}

export const actions = {

  async GET_ALBUNS ({ commit }, payload) {
    try {
      const data = await this.$axios.$get('http://localhost:57987/album/getAlbuns')

      if (data) {
        commit('SET_ALBUNS', data)
      }

      return true
    } catch (error) {
    }
  },
  async GET_ALBUM ({ commit }, payload) {
    try {
      const data = await this.$axios.$get('http://localhost:57987/album/getalbum/' + payload)
      if (data) {
        commit('SET_ALBUM', data)
      }

      return !!data
    } catch (error) {
    }
  },
  async POST_ALBUM ({ commit }, payload) {
    try {
      const data = await this.$axios.$post('http://localhost:57987/album/post', payload)
      if (data) {
        console.log('retornou o novo album da api')
        console.log(data)
        commit('POST_ALBUM', data)
        return true
      }

      return data
    } catch (error) {
    }
  },
  async PUT_ALBUM ({ commit }, payload) {
    try {
      const data = await this.$axios.$put('http://localhost:57987/album', payload)
      if (data) {
        commit('PUT_ALBUNS', payload)
        return true
      }

      return data
    } catch (error) {
    }
  },
  async SET_ALBUM ({ commit }, payload) {
    console.log('entrou no set')
    console.group(payload)
    try {
      commit('PUT_ALBUM', payload)
    } catch (error) {
    }
  },
  async DELETE_FOTO ({ commit }, payload) {
    console.log('entrou no deleteFoto')
    console.group(payload)
    try {
      commit('DELETE_FOTO', payload)
    } catch (error) {
    }
  },
  async PUT_FOTO ({ commit }, payload) {
    console.log('entrou no PUT')
    console.group(payload)
    try {
      commit('PUT_FOTO', payload)
    } catch (error) {
    }
  },
  async DELETE_ALBUM ({ commit }, payload) {
    try {
      const data = await this.$axios.$delete('http://localhost:57987/album/delete/' + payload)

      if (data) {
        commit('DELETE_ALBUM', payload)
        return true
      }
      return data
    } catch (error) {
    }
  }
}

export const getters = {
  GET_ALBUNS: (state, getters) => {
    return state.albuns
  },

  GET_ALBUM: (state, getters) => {
    return state.album
  }

}
