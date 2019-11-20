export const state = () => ({
    errors: [],
    isLoading: false
  })
  
  export const mutations = {
  
    TOGGLE_LOADING (state, payload) {
      state.isLoading = payload !== undefined ? payload : !state.isLoading
    },
  
    SET_ERROR (state, payload = []) {
      state.errors = payload
    }
  }