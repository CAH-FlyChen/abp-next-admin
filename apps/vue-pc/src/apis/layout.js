
import httpInstance from "@/utils/http"

export function getCategoryAPI () {
  return httpInstance({
    url: '/api/product/category/treedata'
  })
}