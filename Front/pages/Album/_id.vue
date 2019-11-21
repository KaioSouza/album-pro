<template>
  <v-container
    class="fill-height"
    fluid
  >
    <v-row
      align="center"
      justify="center"
    >
      <v-col
        cols="12"
        sm="12"
        md="12"
      >
        <v-card class="elevation-0">
          <v-card-text>
            <v-row
              align="center"
              justify="center"
            >
              <v-col class="text-right" cols="12" sm="12">
                <div class="my-2">
                  <v-dialog v-model="modalFotoExpandida">
                    <v-container>
                      <v-img :src="image64Base" alt="" centered />
                    </v-container>
                  </v-dialog>
                  <v-dialog v-model="dialog" persistent max-width="600px">
                    <v-card>
                      <v-card-title>
                        <span class="headline">Envio de Foto(s)</span>
                      </v-card-title>
                      <v-card-text>
                        <v-container>
                          <v-row>
                            <v-col cols="12">
                              <v-file-input
                                v-model="files"
                                :show-size="1000"
                                color="deep-purple accent-4"
                                counter
                                label="Envio"
                                multiple
                                placeholder="Selecione as fotos"
                                prepend-icon="mdi-paperclip"
                                outlined
                              >
                                <template v-slot:selection="{ index, text }">
                                  <v-chip
                                    v-if="index < 2"
                                    color="deep-purple accent-4"
                                    dark
                                    label
                                    small
                                  >
                                    {{ text }}
                                  </v-chip>

                                  <span
                                    v-else-if="index === 2"
                                    class="overline grey--text text--darken-3 mx-2"
                                  >
                                    +{{ files.length - 2 }} File(s)
                                  </span>
                                </template>
                              </v-file-input>
                            </v-col>
                          </v-row>
                        </v-container>
                        <!-- <small>Tamanho total máximo permitido: 1mb</small> -->
                      </v-card-text>
                      <v-card-actions>
                        <v-spacer />
                        <v-btn @click="dialog = false" color="blue darken-1" text>
                          Cancelar
                        </v-btn>
                        <v-btn @click="dialog = false, adicionarFoto()" color="blue darken-1" text>
                          Enviar
                        </v-btn>
                      </v-card-actions>
                    </v-card>
                  </v-dialog>
                  <v-dialog v-model="dialogAtualizar" persistent max-width="600px">
                    <v-card>
                      <v-card-title>
                        <span class="headline">{{ `Atualizar Foto '${novafoto.nome}'` }}</span>
                      </v-card-title>
                      <v-card-text>
                        <v-container>
                          <v-row>
                            <v-col cols="12">
                              <v-text-field
                                v-model="novafoto.nome"
                                label="Nome da Foto"
                              />
                            </v-col>
                          </v-row>
                        </v-container>
                      </v-card-text>
                      <v-card-actions>
                        <v-spacer />
                        <v-btn @click="dialogAtualizar = false" color="blue darken-1" text>
                          Cancelar
                        </v-btn>
                        <v-btn @click="dialogAtualizar = false, atualizar()" color="blue darken-1" text>
                          Atualizar
                        </v-btn>
                      </v-card-actions>
                    </v-card>
                  </v-dialog>
                  <v-btn
                    @click.stop="dialog = true"
                    color="primary"
                    class="ma-2"
                    outlined
                  >
                    <v-icon left>
                      mdi-plus
                    </v-icon>
                    Adicionar Foto
                  </v-btn>
                </div>
              </v-col>
            </v-row>
            <v-row
              align="center"
              justify="left"
            >
              <v-col
                v-for="foto in album.fotos"
                :key="foto.id"
                :cols="12"
                sm="12"
                md="3"
              >
                <v-card
                  class="mx-auto"
                  max-width="344"
                >
                  <v-img v-if="foto.base64String !== null"
                    :src="foto.base64String"
                    height="150px"
                  />

                  <v-card-title>
                    {{ foto.nome }}
                  </v-card-title>

                  <v-card-subtitle>
                    {{ 'Criado em: ' + foto.criadoEm }}
                  </v-card-subtitle>

                  <v-card-actions>
                    <v-spacer />
                    <v-btn
                      icon
                    >
                      <v-icon
                        @click="modalFotoExpandida = true, image64Base = foto.base64String"
                        small
                      >
                        mdi-eye
                      </v-icon>
                    </v-btn>
                    <v-btn
                    
                      @click="passarParametro(foto), dialogAtualizar = true"
                      icon
                    >
                      <v-icon 
                        small>
                        mdi-pencil
                      </v-icon>
                    </v-btn>
                    <v-btn
                    @click="passarParametro(foto), deletar()"
                      icon
                    >
                      <v-icon  small>
                        mdi-delete
                      </v-icon>
                    </v-btn>
                  </v-card-actions>
                </v-card>
              </v-col>
            </v-row>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  middleware: 'authenticated',
  data: () => ({
    files: null,
    album: [],
    image64Base: '',
    modalFotoExpandida: false,
    novafoto: {
      nome: '',
    },
    dialog: false,
    dialogAtualizar: false,
    images: {
      album: require('@/static/album-compressed.png')
    }
  }),
  async created () {
    const data = await this.$store.dispatch('album/GET_ALBUM', this.$route.params.id)
    if (data) {
      this.album = this.$store.state.album.album
    }
  },
  methods: {
 
    async adicionarFoto () {
      
      const obj = {
        files: this.files,
        albumId: this.$route.params.id,
      }
      const result = await this.$store.dispatch('foto/POST_FOTOS', obj)
      if (result) {
        this.album = this.$store.state.album.album
      }
    },
    async passarParametro (foto) {
     
      const obj = {
        nome: foto.nome,
        id: foto.id,
        albumID: foto.albumID
      }
      this.novafoto = obj
    },
    async atualizar(){
    
      const result = await this.$store.dispatch('foto/PUT_FOTO', this.novafoto)
      if (result) {
        this.album = this.$store.state.album.album
      }
    },
     async deletar(){
      
      const result = await this.$store.dispatch('foto/DELETE_FOTO', this.novafoto)
      if (result) {
        this.album = this.$store.state.album.album
      }
    }
  }
}
</script>
<style>
</style>
