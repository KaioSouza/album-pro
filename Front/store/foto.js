export const state = () => ({
  fotos: [],
  foto: null
})

export const mutations = {

  SET_FOTOS (state, data) {
    state.fotos = data
  },

  SET_FOTO (state, data) {
    state.foto = data
  }
}

export const actions = {

  async GET_FOTOS ({ commit }, payload) {
    try {
      const data = await this.$axios.$get('http://localhost:57987/foto')
      console.log(data)

      if (data) {
        commit('SET_FOTOS', data)
      }

      return true
    } catch (error) {
    }
  },
  async GET_FOTO ({ commit }, payload) {
    try {
      const data = await this.$axios.$get('http://localhost:57987/foto' + payload)
      console.log(data)

      if (data) {
        commit('SET_FOTO', data)
      }

      return !!data
    } catch (error) {
    }
  },
  async POST_FOTOS ({ commit, dispatch }, payload) {
    try {
      const formData = new FormData()

      for( var i = 0; i < payload.files.length; i++ ){
        let file = payload.files[i];
      
        formData.append('files[' + i + ']', file);
      }
      
      const data = await this.$axios.$post('http://localhost:57987/foto/post/' + payload.albumId, 
        formData,
        {
          headers: {
              'Content-Type': 'multipart/form-data'
          }
        }
      )
      console.log('album retornardo')
      console.log(data)
      if (data) {
        const result = await dispatch('album/SET_ALBUM', data, { root: true })
      }

      return !!data
    } catch (error) {
    }
  },
  async PUT_FOTO ({ commit, dispatch }, payload) {
    console.log(payload)
    try {
      const data = await this.$axios.$put('http://localhost:57987/foto', payload)
      if (data) {
        console.log('entrou no data')
        const result = await dispatch('album/PUT_FOTO', payload, { root: true })
      }

      return result
    } catch (error) {
    }
  }, 

  async DELETE_FOTO ({ commit, dispatch }, payload) {
    try {
      const data = await this.$axios.$put('http://localhost:57987/foto/delete', payload)
      if (data) {
        const result = await dispatch('album/DELETE_FOTO', payload, { root: true })
      }
      return result
    } catch (error) {
    }
  }
}

export const getters = {
  GET_FOTOS: (state, getters) => {
    return state.fotos
  },

  GET_FOTO: (state, getters) => {
    return state.foto
  }

}
